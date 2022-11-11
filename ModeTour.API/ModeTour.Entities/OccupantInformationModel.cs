﻿namespace ModeTour.Entities
{
    public class OccupantInformationModel
    {
        /// <summary>
        /// Customer type ((ADT/CHD/INF))
        /// </summary>
        public string PTC { get; set; }
        /// <summary>
        /// Sex (MR/MRS/MS/MSTR/MISS)
        /// </summary>
        public string PTl { get; set; }
        /// <summary>
        /// Korea name
        /// </summary>
        public string PHN { get; set; }
        /// <summary>
        /// English name (SurName)
        /// </summary>
        public string PSN { get; set; }
        /// <summary>
        /// English name (FirstName)
        /// </summary>
        public string PFN { get; set; }
        /// <summary>
        /// Date of birth (yyyyMMdd, required with children)
        /// </summary>
        public string PDB { get; set; }
        /// <summary>
        /// Phone number
        /// </summary>
        public string PMN { get; set; }
        /// <summary>
        /// Classification of passenger membership (01: regular member, 02: web member, 03: travel mileage member)
        /// </summary>
        public string PMC { get; set; }
        /// <summary>
        /// Passenger's mileage card number
        /// </summary>
        public string PMT { get; set; }
        /// <summary>
        /// Does the passenger claim to earn travel mileage?
        /// </summary>
        public string PMR { get; set; }

    }
}
