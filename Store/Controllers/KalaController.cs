using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Data;
using Store.Models;
using Store.Service;

namespace Store.Controllers
{
    
    public class KalaController : Controller
    {
        private readonly IKalaRepository _repo;
        

        private readonly IMapper _mapper;

        public KalaController(IKalaRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        // GET: Kala
        [Authorize(Roles = "Administrator,User")]
        public ActionResult Index()
        {
            var kala = _repo.FindAll().ToList();
            var model = _mapper.Map<List<Kala>,List<DetailKalaViewModel>>(kala);
            return View(model);
        }

        // GET: Kala/Details/5
        [Authorize(Roles = "Administrator,User")]
        public ActionResult Details(int id)
        {
            if (!_repo.isExists(id))
            {
                return NotFound();
            }

            var kala = _repo.FindById(id);
            var model = _mapper.Map<DetailKalaViewModel>(kala);
            return View(model);
        }

        // GET: Kala/Create
        [Authorize(Roles = "Administrator,User")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kala/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator,User")]
        public ActionResult Create(DetailKalaViewModel model)
        {
            try
            {
                // TODO: Add insert logic here
                if (!ModelState.IsValid)
                {
                    return View();
                }

                var kala = _mapper.Map<Kala>(model);
                var isSuccess = _repo.Create(kala);
                if (!isSuccess)
                { 
                    ModelState.AddModelError("", "please check once again");
                    return View(model);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "please check once again");
                return View();
            }
        }

        // GET: Kala/Edit/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int id)
        {
            if (!_repo.isExists(id))
            {
                return NotFound();
            }

            var kala = _repo.FindById(id);
            var model = _mapper.Map<DetailKalaViewModel>(kala);
            return View(model);
        }

        // POST: Kala/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int id, DetailKalaViewModel model)
        {
            try
            {
                // TODO: Add update logic here
                if (!ModelState.IsValid)
                {
                    return View();
                }

                var kala = _mapper.Map<Kala>(model);
                var isSuccess = _repo.Update(kala);
                
                if (!isSuccess)
                { 
                    ModelState.AddModelError("", "please check once again");
                    return View(model);
                }

                return RedirectToAction(nameof(Index));
                
            }
            catch
            {
                ModelState.AddModelError("", "please check once again");
                return View();
            }
        }

        // GET: Kala/Delete/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int id)
        {
            // if (!_repo.isExists(id))
            // {
            //     return NotFound();
            // }
            //
            // var kala = _repo.FindById(id);
            // var model = _mapper.Map<DetailKalaViewModel>(kala);
            // return View(model);
            var kala = _repo.FindById(id);
            var isSuccess = _repo.Delete(kala);
            if (!isSuccess)
            {
                return BadRequest();
            }
            return RedirectToAction(nameof(Index));
            
        }

        // POST: Kala/Delete/5
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public ActionResult Delete(int id, DetailKalaViewModel model)
        // {
        //     try
        //     {
        //         // TODO: Add delete logic here
        //         var kala = _repo.FindById(id);
        //         var isSuccess = _repo.Delete(kala);
        //         if (!isSuccess)
        //         {
        //             return View(model);
        //         }
        //         return RedirectToAction(nameof(Index));
        //     }
        //     catch
        //     {
        //         return View(model);
        //     }
        // }
    }
}