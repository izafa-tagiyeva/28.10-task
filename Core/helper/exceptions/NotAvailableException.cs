using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.helper.exceptions
{
    public class NotAvailableException:Exception
    {
        public NotAvailableException():base(){ }

        public NotAvailableException(string message):base(message){}


    }
}
/*Aşağıdakı custom exception-ı yaradın:
- NotAvailableException
*/