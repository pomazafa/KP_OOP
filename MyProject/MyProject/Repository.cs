using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject
{
    interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }

    public class AddressRepository : IRepository<ADDRESS>
    {
        private MyDatabase db;

        public AddressRepository(MyDatabase context)
        {
            this.db = context;
        }

        public IEnumerable<ADDRESS> GetAll()
        {
            return db.ADDRESS;
        }

        public ADDRESS Get(int id)
        {
            return db.ADDRESS.Find(id);
        }

        public void Create(ADDRESS adr)
        {
            db.ADDRESS.Add(adr);
        }

        public void Update(ADDRESS adr)
        {
            db.Entry(adr).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            ADDRESS adr = db.ADDRESS.Find(id);
            if (adr != null)
                db.ADDRESS.Remove(adr);
        }
    }

    public class PatientRepository : IRepository<PATIENT>
    {
        private MyDatabase db;

        public PatientRepository(MyDatabase context)
        {
            this.db = context;
        }

        public IEnumerable<PATIENT> GetAll()
        {
            return db.PATIENT;
        }

        public PATIENT Get(int id)
        {
            return db.PATIENT.Find(id);
        }

        public void Create(PATIENT pat)
        {
            db.PATIENT.Add(pat);
        }

        public void Update(PATIENT pat)
        {
            db.Entry(pat).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            PATIENT pat = db.PATIENT.Find(id);
            if (pat != null)
                db.PATIENT.Remove(pat);
        }
    }

    public class RecipeRepository : IRepository<RECIPE>
    {
        private MyDatabase db;

        public RecipeRepository(MyDatabase context)
        {
            this.db = context;
        }

        public IEnumerable<RECIPE> GetAll()
        {
            return db.RECIPE;
        }

        public RECIPE Get(int id)
        {
            return db.RECIPE.Find(id);
        }

        public void Create(RECIPE rec)
        {
            db.RECIPE.Add(rec);
        }

        public void Update(RECIPE rec)
        {
            db.Entry(rec).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            RECIPE rec = db.RECIPE.Find(id);
            if (rec != null)
                db.RECIPE.Remove(rec);
        }
    }



    public class VisitRepository : IRepository<VISIT>
    {
        private MyDatabase db;

        public VisitRepository(MyDatabase context)
        {
            this.db = context;
        }

        public IEnumerable<VISIT> GetAll()
        {
            return db.VISIT;
        }

        public VISIT Get(int id)
        {
            return db.VISIT.Find(id);
        }

        public void Create(VISIT vis)
        {
            db.VISIT.Add(vis);
        }

        public void Update(VISIT vis)
        {
            db.Entry(vis).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            VISIT vis = db.VISIT.Find(id);
            if (vis != null)
                db.VISIT.Remove(vis);
        }
    }

    public class UsersRepository : IRepository<USERS>
    {
        private MyDatabase db;

        public UsersRepository(MyDatabase context)
        {
            this.db = context;
        }

        public IEnumerable<USERS> GetAll()
        {
            return db.USERS;
        }

        public USERS Get(int id)
        {
            return db.USERS.Find(id);
        }

        public void Create(USERS user)
        {
            db.USERS.Add(user);
        }

        public void Update(USERS user)
        {
            db.Entry(user).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            USERS vis = db.USERS.Find(id);
            if (vis != null)
                db.USERS.Remove(vis);
        }
    }
}
