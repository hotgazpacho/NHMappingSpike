using System;
using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Testing;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NHMappingSpike.Entities;
using NHMappingSpike.ValueTypes;
using NUnit.Framework;

namespace NHMappingSpike
{
    [TestFixture]
    public class PersistenceTests
    {
        protected Configuration configuration;
        protected ISessionFactory SessionFactory;
        protected ISession Session;

        [TestFixtureSetUp]
        public void BeforeAll()
        {
            configuration = Fluently.Configure()
                .Database(SQLiteConfiguration.Standard.InMemory().ShowSql())
                .Mappings(m =>
                              {
                                  m.FluentMappings
                                      .AddFromAssembly(Assembly.GetExecutingAssembly())
                                      .ExportTo(".");
                                  m.HbmMappings.AddFromAssembly(Assembly.GetExecutingAssembly());
                              })
                .BuildConfiguration();
            SessionFactory = configuration.BuildSessionFactory();
        }

        [SetUp]
        public void BeforeEach()
        {
            Session = SessionFactory.OpenSession();
            new SchemaExport(configuration).Execute(true, true, false, Session.Connection, Console.Out);
        }

        [Test]
        public void CanCorrectlyMapItemRevControl()
        {
            new PersistenceSpecification<ItemRevControl>(Session)
                .CheckProperty(x => x.ItemId, 1)
                .CheckProperty(x => x.RevNo, 100)
                .VerifyTheMappings();
        }

        [Test]
        public void CanCorrectlyMapComponentMaster()
        {
            var itemRevControl = new ItemRevControl(1);
            Session.Save(itemRevControl);
            var itemKey = new ItemRevKey(itemRevControl, 100);
            new PersistenceSpecification<Component>(Session)
                .CheckProperty(c => c.ItemRevKey, itemKey)
                .CheckProperty(c => c.Name, "My Name")
                .VerifyTheMappings(new Component(itemKey, "My Name"));
        }

        [Test]
        public void CanCorrectlyMapComponentWithDetails()
        {
            var itemRevControl = new ItemRevControl(1);
            Session.Save(itemRevControl);
            var itemKey = new ItemRevKey(itemRevControl, 100);
            new PersistenceSpecification<ComponentWithDetails>(Session)
                .CheckProperty(c => c.ItemRevKey, itemKey)
                .CheckProperty(c => c.Name, "My Name")
                .CheckProperty(c => c.Category, "My Category")
                .CheckProperty(c => c.Cost, 1999.95)
                .CheckProperty(c => c.IsCertified, true)
                .VerifyTheMappings(new ComponentWithDetails(itemKey, "My Name"));
        }

        [TearDown]
        public void AfterEach()
        {
            Session.Dispose();   
        }

        [TestFixtureTearDown]
        public void AfterAll()
        {
            SessionFactory.Dispose();
        }
    }
}