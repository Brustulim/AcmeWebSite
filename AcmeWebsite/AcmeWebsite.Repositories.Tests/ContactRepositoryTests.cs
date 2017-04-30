using System;
using System.Linq;
using AcmeWebsite.Domain.Entities;
using AcmeWebsite.Domain.IRepositories;
using AcmeWebsite.Domain.ValueObject;
using AcmeWebsite.Repositories.Tests.TestData;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AcmeWebsite.Repositories.Tests
{
    [TestClass]
    public class ContactRepositoryTests
    {

        /*

        private readonly IContactRepository _contactRepository;
        //private readonly RepositoryForTests<Contact> _repository;

       // private readonly RepositoryBase<Contact> _repositoryBase;


        public ContactRepositoryTests()
        {
            //Use the testData Class for populate Repository (the in memory one)
            //_repository = new RepositoryForTests<Contact>(ContactTestData.Get());

            //Instantiate _contactRepository with de "Context" from memory
            //Before tests we can change for database for extra tests with the real ambient
            //_contactRepository = new ContactRepository(_repository);
            _contactRepository = new ContactRepository();
            ContactTestData.AddOrUpdateTestData(_contactRepository);

            //_repositoryBase = new ContactRepository(_contactRepository);
            //_contactRepository = new ContactRepository(_repositoryBase);

        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ContactRepository_Error_Without_Name()
        {
            Contact Contact = new Contact("", "Rogers", new Email("buck@mailinator.com"), new Phone("(321) 888-9999"), "PN", 21, "Buck from tests!");
            //_contactRepository.Save(Contact);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ContactRepository_Error_Email_Invalid()
        {
            Contact Contact = new Contact("", "Rogers", new Email("mailinator.com"), new Phone("(321) 888-9999"), "PN", 21, "Buck from tests!");
            //_contactRepository.Save(Contact);
        }


        [TestMethod]
        public void ContactRepository_Save()
        {
            Contact Contact = new Contact("Buck", "Rogers", new Email("planet@mailinator.com"), new Phone("(321) 888-9999"), "PN", 21, "Buck from tests!");

            int itensBeforeSave = _contactRepository.Get().Count();

            _contactRepository.Save(Contact);

            int itensAfterSave = _contactRepository.Get().Count();

            //Assert.IsTrue(_repository.isCommited);
            Assert.AreEqual(itensBeforeSave + 1, itensAfterSave);
        }

        [TestMethod]
        public void ContactRepository_Get_By_Id()
        {
            Contact Contact = _contactRepository.First();
            Assert.AreEqual(Contact, _contactRepository.Get(Contact.Id));
        }

        [TestMethod]
        public void ContactRepository_Get_By_Id_Not_Exists()
        {
            Contact Contact = _contactRepository.Get(9999);
            Assert.IsNull(Contact);
        }

        [TestMethod]
        public void ContactRepository_Get_By_Email_Exists()
        {
            Contact Contact = _contactRepository.GetByEmail(new Email("theking@mailinator.com"));
            Assert.AreEqual(Contact.Name, "Michael");
        }


        [TestMethod]
        public void ContactRepository_Get_By_Email_No_Exists()
        {
            Contact Contact = _contactRepository.GetByEmail(new Email("x@mailinator.com"));
            Assert.IsNull(Contact);
            
        }


        //Todo: Analyze and implement other Unit Tests

    */
    }
}
