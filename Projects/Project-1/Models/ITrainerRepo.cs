using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public interface ITrainerRepo<T>
    {
        public IEnumerable<T> GetDetails();

        public void AddDetails(T obj);

        public void UpdateDetails(T obj);

        public T DeleteDetails(T obj);
    }
}
