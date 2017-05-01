namespace AcmeWebsite.Repositories
{
    /*
    public class ContactRepository_old : RepositoryBase<Contact>, IContactRepository
    {

        
        //For use base class/interface IRepository
        //Private force developer to call constructor to instantiate and cant change this reference
        private readonly IRepositoryBase<Contact> _contactRepository;

        public ContactRepository_old(IRepositoryBase<Contact> contactRepository) : base()
        {
            _contactRepository = contactRepository;
        }
        
        //Needed for RespositoryForTests that use in Memory list
        public Contact Get(int id)
        {
            return _contactRepository.Get(id);
        }
        

        public Contact GetByEmail(Email email)
        {
            return _contactRepository.Get().FirstOrDefault(c => c.Email.Address == email.Address);
        }

        public void Save(Contact contact)
        {
            _contactRepository.AddOrUpdate(contact);
            _contactRepository.Commit();
        }
        
    }
    */
}
