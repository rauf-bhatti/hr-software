using System;
using System.Collections.Generic;
using System.Text;
using AspireWebHR.Database;

namespace AspireWebHR.Controllers
{
    public abstract class Controller
    {
        protected Database.Database dbInstance = new Database.Database();
    }
}
