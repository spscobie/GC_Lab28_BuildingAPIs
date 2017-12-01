using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GC_Deliverable24_Lab28_CreateWebAPI.Models;

namespace GC_Deliverable24_Lab28_CreateWebAPI.Controllers
{
    public class MovieController : ApiController
    {
        Random randNum = new Random();

        [HttpGet]
        public string[] GetMovieCategories ()
        {
            MoviesEntities ORM = new MoviesEntities();

            string[] categories = (from m in ORM.Movies
                                   select m.Category).Distinct().OrderBy(Category => Category).ToArray();

            return categories;
        }

        [HttpGet]
        public List<Movy> GetMovies ()
        {
            MoviesEntities ORM = new MoviesEntities();

            return ORM.Movies.ToList();
        }

        [HttpGet]
        public List<Movy> GetMoviesByCategory (string catName)
        {
            //if (catName == null)
            //{
            //    List<Movy> badReq = new List<Movy> { (Movy)HttpStatusCode.BadRequest };

            //    return badReq;
            //}

            MoviesEntities ORM = new MoviesEntities();

            List<Movy> movieLst = (from m in ORM.Movies
                                   where m.Category == catName
                                   select m).ToList();

            return movieLst;
        }

        [HttpGet]
        public Movy GetRandomMovie ()
        {
            MoviesEntities ORM = new MoviesEntities();

            List<Movy> movieLst = ORM.Movies.ToList();

            return movieLst[randNum.Next(movieLst.Count)];
        }

        [HttpGet]
        public Movy GetRandomMovieByCat (string catName)
        {
            MoviesEntities ORM = new MoviesEntities();

            List<Movy> movieLst = (from m in ORM.Movies
                                   where m.Category == catName
                                   select m).ToList();

            return movieLst[randNum.Next(movieLst.Count)];
        }

        [HttpGet]
        public List<Movy> GetRandomMovies(int numMovies)
        {
            MoviesEntities ORM = new MoviesEntities();

            List<Movy> movieLst = ORM.Movies.ToList();
            List<Movy> selection = new List<Movy>();

            for (int i = 0; i < numMovies; i++)
            {
                selection.Add(movieLst[randNum.Next(movieLst.Count)]);
            }

            return selection;
        }
    }
}