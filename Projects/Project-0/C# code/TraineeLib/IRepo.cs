using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraineeLib;

namespace Trainer
{
    public interface IRepo<T, L>
    {
        /// <summary>
        /// Fetches all the Details of Traiee
        /// </summary>
        /// <returns> TLogin object </returns>
        public T fetchDetails(L obj);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="login"></param>
        /// <returns> TLogin </returns>
        public T AddTrainee(T login);

    }
}
