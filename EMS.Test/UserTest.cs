using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace EMS.Test
{
    [TestFixture]
    public class UseerTest
    {
        Admin ad;
        User us;
        User us1;
        IList<User> ulist;
        [SetUp]
        public void Init()
        {
            ad = new Admin();
            us = new User();
            ulist = new List<User>();
            ulist.Add(us);
            ad.Adduser("diva", "Male", "2345676543", "efgfrtgfgh", "customer", "diva1212", "diva");
           

        }
        [Test]
        public void when_adminaddtheuser_expects_useradded()
        {
            ////arrange
            //Admin aobj = new Admin();
            ////act
            //string actualResult = aobj.Adduser("diva", "Male", "2345676543", "efgfrtgfgh", "customer", "diva1212", "diva");
            //assert
            //Assert.AreEqual("user added", actualResult);
            string actualResult = ad.Adduser("diva", "Male", "23456765436", "efgfrtgfgh", "customer", "diva1212", "diva");
            Assert.AreEqual("user added", actualResult);

        }
        [Test]
        public void when_adminaddthesameuser_expects_userexists()
        {
            /* //arrange
             Admin aobj = new Admin();
             aobj.Adduser("diva", "Male", "2345676543", "efgfrtgfgh", "customer", "diva1212", "diva");
             //act
             string actualResult = aobj.Adduser("diva", "Male", "2345676543", "efgfrtgfgh", "customer", "diva1212", "diva");
             //assert
             Assert.AreEqual("user already exists", actualResult);
             */
            string actualResult = ad.Adduser("diva", "Male", "2345676543", "efgfrtgfgh", "customer", "diva1212", "diva");
            Assert.AreEqual("user already exists", actualResult);

        }


    }
}
