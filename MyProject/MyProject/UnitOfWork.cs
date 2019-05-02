using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject
{
    class UnitOfWork
    {
        private MyDatabase db = new MyDatabase();
        private VisitRepository visitRepository;
        private AddressRepository addressRepository;
        private UsersRepository usersRepository;
        private PatientRepository patientRepository;
        private RecipeRepository recipeRepository;

        public RecipeRepository Recipes
        {
            get
            {
                if (recipeRepository == null)
                    recipeRepository = new RecipeRepository(db);
                return recipeRepository;
            }
        }
        public PatientRepository Patients
        {
            get
            {
                if (patientRepository == null)
                    patientRepository = new PatientRepository(db);
                return patientRepository;
            }
        }
        public UsersRepository Users
        {
            get
            {
                if (usersRepository == null)
                    usersRepository = new UsersRepository(db);
                return usersRepository;
            }
        }
        public VisitRepository Visits
        {
            get
            {
                if (visitRepository == null)
                    visitRepository = new VisitRepository(db);
                return visitRepository;
            }
        }

        public AddressRepository Addresses
        {
            get
            {
                if (addressRepository == null)
                    addressRepository = new AddressRepository(db);
                return addressRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
