using BasicApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasicApp.Services
{
    public interface IDomainRepository
    {
        

        Domains GetDomainData(int userID);
        
        
        void InsertDomain(Domains domains);
        
    }
}
