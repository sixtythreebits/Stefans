using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Xml.Linq;
using Core.Utilities;
using Lib;

namespace Core.CM
{
    public class PromoImage : CoreObjectBase
    {
        #region Properties
        /// <summary>
        /// PromoImageID field of PromoImages table
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Image field of PromoImages table
        /// </summary>
        public string Image { get; set; }
        /// <summary>
        /// PromoName field of PromoImages table
        /// </summary>
        [Required(ErrorMessage = "Name  is required")]
        [StringLength(50)]
        public string PromoName { get; set; }
        /// <summary>
        /// SortIndex field of PromoImages table
        /// </summary>
        public int? SortIndex { get; set; }
        /// <summary>
        /// CRTime field of PromoImages table
        /// </summary>
        public DateTime? CRTime { get; set; } 
        #endregion

        #region Methods
        /// <summary>
        /// CRUD operations on PromoImages table
        /// </summary>
        /// <param name="iud"></param>
        /// <param name="PromoImageID"></param>
        /// <param name="Image"></param>
        /// <param name="PromoName"></param>
        /// <param name="SortIndex"></param>
        public void TSP(byte iud, int? PromoImageID, string Image, string PromoName, int? SortIndex = null)
        {
            TryExecute(db =>
            {
                db.tsp_PromoImages(iud, ref PromoImageID, Image, PromoName, SortIndex);
                ID = PromoImageID ?? 0;
            } , Logger: string.Format("TSP(iud = {0}, ID = {1}, Image = {2}, PromoName = {3}, SortIndex = {4})"
              , iud, ID, Image, PromoName, SortIndex));
        }
        /// <summary>
        /// Get list of PromoImage objects
        /// </summary>
        /// <returns></returns>
        public List<PromoImage> List_PromoImages()
        {
            return TryToReturn(db => db.List_PromoImages().Select(c => new PromoImage
            {
                ID = c.PromoImageID,
                Image = c.Image,
                PromoName = c.PromoName,
                SortIndex = c.SortIndex,
                CRTime = c.CRTime
            }).OrderByDescending(x => x.CRTime).OrderBy(x => x.SortIndex).ToList(),
            Logger: string.Format("List_PromoImages(ID = {0}, Image = {1}, PromoName = {2}, SortIndex = {3})", ID, Image, PromoName, SortIndex));
        }
        #endregion
    }
}
