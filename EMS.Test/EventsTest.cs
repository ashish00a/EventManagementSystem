using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace EMS.Test
{
    [TestFixture]
    public class EventsTest
    {
        Events el;
        IList<Events> elist;
        [SetUp]
        public void Init()
        {
            el = new Events();
            elist = new List<Events>();
            elist.Add(el);
            el.AddEvent("mahothsav", "cultural", 25000, 10000, 15000, 0);
        }

        [Test]
        public void when_adminaddtheevent_expects_eventadded()
        {
            /* //arrange
             Events addevent = new Events();
             //act
             string actualResult = addevent.AddEvent("mahothsav", "cultural", 25000, 10000, 15000, 0);
             //assert
             Assert.AreEqual("Event added", actualResult);
             */
            string actualResult = el.AddEvent("mahothsav1", "cultural", 25000, 10000, 15000, 0);
            Assert.AreEqual("Event added", actualResult);

        }
        [Test]
        public void when_adminaddthesameevent_expects_eventaddexists()
        {
            /*//arrange
            Events addevent = new Events();
            addevent.AddEvent("mahothsav", "cultural", 25000, 10000, 15000, 0);
            //act
            string actualResult = addevent.AddEvent("mahothsav", "cultural", 25000, 10000, 15000, 0);
            //assert
            Assert.AreEqual("Events already exists", actualResult);
            */
            string actualResult = el.AddEvent("mahothsav", "cultural", 25000, 10000, 15000, 0);
            Assert.AreEqual("Events already exists", actualResult);

        }
    }
}
