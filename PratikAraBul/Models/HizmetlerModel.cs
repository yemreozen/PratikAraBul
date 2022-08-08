

using PratikAraBul.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PratikAraBul.Models
{
    public class HizmetlerModel
    {
        public IEnumerable<tblHizmetler> HizmetlerList { get; set; }
        public IEnumerable<tblHizmetKategori> HizmetKategoriList { get; set; }
        public IEnumerable<tblPopularHizmet> PopularHizmetList { get; set; }
        public IEnumerable<tblCommend> CommendList { get; set; }

        public tblHizmetler Hizmetler { get; set; }
    }
}