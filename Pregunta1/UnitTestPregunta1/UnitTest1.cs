using System;
using System.Net;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pregunta1.Controllers;
using Pregunta1.Models;

namespace UnitTestPregunta1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGet()
        {
            //ARRANGE
            TapiasController controller = new TapiasController();
            //ACT
            var listaPersonas = controller.GetTapias();
            //ASSERT
            Assert.IsNotNull(listaPersonas);
        }
        [TestMethod]
        public void TestPost()
        {    //ARRANGE
            TapiasController controller = new TapiasController();
            Tapia tapia = new Tapia()
            {
                TapiaID = 1,
                FriendofTapia = "Paulo Loayza",
                place = Places.Montero,
                Email = "Profe@gmail.com",
                Birthdate = DateTime.Now
            };
            //ACT
            IHttpActionResult actionResult = controller.PostTapia(tapia);
            var createdResult = actionResult as CreatedAtRouteNegotiatedContentResult<Tapia>;
            //ASSERT
            Assert.IsNotNull(createdResult);
            Assert.AreEqual("DefaultApi", createdResult.RouteName);
            Assert.IsNotNull(createdResult.RouteValues["id"]);
        }
        [TestMethod]
        public void TestPut()
        {
            //ARRANGE
            TapiasController controller = new TapiasController();
            Tapia tapia = new Tapia()
            {
                TapiaID = 2,
                FriendofTapia = "Mascapito XD",
                place = Places.Montero,
                Email = "elmascapito@gmail.com",
                Birthdate = DateTime.Now
            };
            //ACT
            IHttpActionResult actionResultPost = controller.PostTapia(tapia);
            var result = controller.PutTapia(tapia.TapiaID, tapia) as StatusCodeResult;
            //ASSERT
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(StatusCodeResult));
            Assert.AreEqual(HttpStatusCode.NoContent, result.StatusCode);
        }
        [TestMethod]
        public void TestDelete()
        {
            //ARRANGE
            TapiasController controller = new TapiasController();
            Tapia tapia = new Tapia()
            {
                TapiaID = 3,
                FriendofTapia = "El de limpieza",
                place = Places.Warnes,
                Email = "limpiador@gmail.com",
                Birthdate = DateTime.Now
            };
            //ACT
            IHttpActionResult actionResultPost = controller.PostTapia(tapia);
            IHttpActionResult actionResultDelete = controller.DeleteTapia(tapia.TapiaID);
            //ASSERT
            Assert.IsInstanceOfType(actionResultDelete, typeof(OkNegotiatedContentResult<Tapia>));
        }
    }
}
