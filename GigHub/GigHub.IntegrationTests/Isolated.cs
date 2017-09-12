using NUnit.Framework;
using System;
using System.Transactions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Interfaces;

namespace GigHub.IntegrationTests
{
    public class Isolated : Attribute, ITestAction
    {
        private TransactionScope _transactionScope;
        public ActionTargets Targets {
            get { return ActionTargets.Test; }
        }

    

        public void AfterTest(ITest test)
        {
            _transactionScope.Dispose();
            //throw new NotImplementedException();
        }

      

        public void BeforeTest(ITest test)
        {
            _transactionScope = new TransactionScope();
           // throw new NotImplementedException();
        }
    }
}
