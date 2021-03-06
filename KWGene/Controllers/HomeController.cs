﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GeneBll;

namespace KWGene.Controllers
{
    public class HomeController : Controller
    {
        private readonly GeneDataBLL bll;
        //private readonly NewsBLL newsBll;
        private readonly UserBLL userBll;
        private readonly ProductBLL proBll;
        private readonly LogBLL logBll;
        public HomeController()
        {
            this.bll = Container.Resolver<GeneDataBLL>();
            //this.newsBll = new NewsBLL(); 
            this.userBll = Container.Resolver<UserBLL>();
            this.proBll = Container.Resolver<ProductBLL>();
            this.logBll = Container.Resolver<LogBLL>();
        }
        // GET: Home
        public ActionResult Index()
        {
            List<GeneModel.GeneData> list = new List<GeneModel.GeneData>() {
                new GeneModel.GeneData() {
                      GeneName = "zhang",
                      Organization="万方"
                },
                 new GeneModel.GeneData() {
                      GeneName = "geng",
                      Organization="万方"
                },
            };
            
            //userBll.AddEntity(new GeneModel.User()
            //{
            //    Name = "夏乐",
            //});

            logBll.AddEntity(new GeneModel.Log()
            {
                Problem="1",
                CreateTime = DateTime.Now
            });

            var pp = logBll.GetList(null);

            bll.AddList(list);
            //newsBll.AddList(list2);
            var aa = bll.GetList(null);
            //var bb = userBll.GetList(null);
            //SqlCommonBLL<GeneModel.Patient> bl = new SqlCommonBLL<GeneModel.Patient>();
            //var bb = bl.ExecuteStoreQuery("select * from Patient");
            //var c = bl.GetCountByColumnWithSql("NewsData", "Title", "'zhang'");
            //var cc = newsBll.GetCount(p => true);
            //var dd = newsBll.GetList(null);
            ViewBag.Person = pp;
            return View(aa);
        }
    }
}