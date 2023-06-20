using RohitDI_Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RohitDI_Mvc.RepositoryInterface
{
    interface ISchemeMaster
    {
        int AddUser(Registration entity); // Create
        IQueryable<Registration> ListofRegisteredUser(); //List
        Registration GetSingleRocordID(int? RegistrationID); //Single
        void UpdateUsersReg(Registration Update); //Update
        int RegisterUserDelete(int? RegistrationID);  //Detete
    }
}
