using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI_XamarinDemo.Models;
using WebAPI_XamarinDemo.Data;

namespace WebAPI_XamarinDemo.Controllers
{
    public class PersonController : ApiController
    {
        private List<PersonModel> personList;
        private PersonData personData;
        private PersonModel onePerson;

        public PersonController()
        {
            personList = new List<PersonModel>();
            personData = new PersonData();            
        }

        //Get all persons api/person
        public IHttpActionResult GetAllPersonsf()
        {
            personList = personData.GetAllPersons();
            //PopulateList();
            if (personList == null)
            {
                return NotFound();
            }
            return Ok(personList);
        }

        //Get one person only api/person/id
        public IHttpActionResult GetOnePerson(int id)
        {
            onePerson = new PersonModel();
            onePerson = personData.GetOnePerson(id);
            if(onePerson == null)
            {
                return NotFound();
            }
            return Ok(onePerson);
        }

        //Post, insert a new userflight api/person
        public IHttpActionResult PostNewPerson([FromBody]PersonModel person)
        {
            if (personData.InsertNewPerson(person))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        //Put api/person/id
        public IHttpActionResult PutPerson(int id, [FromBody]PersonModel person)
        {

            if (personData.UpdatePerson(person))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }

        //Delete a flyme, hard delete api/person/id
        public IHttpActionResult DeletePerson(int id)
        {
            if (personData.DeletePerson(id))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
