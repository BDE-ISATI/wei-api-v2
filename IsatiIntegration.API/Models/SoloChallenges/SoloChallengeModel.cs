﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IsatiIntegration.API.Models.SoloChallenges
{
    public class SoloChallengeModel
    {
        /// <summary>
        /// The challenge title
        /// </summary>
        /// <example>Barbecuite</example>
        [Required]
        public string Title { get; set; }
        /// <summary>
        /// The challenge description
        /// </summary>
        /// <example>Participer au barbecue de rentrée</example>
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// The number of point the challenge will give
        /// </summary>
        /// <example>5</example>
        [Required]
        public int Value { get; set; }
        /// <summary>
        /// The number of time the challenge has to be done 
        /// </summary>
        /// <example>1</example>
        [Required]
        public int NumberOfRepetitions { get; set; }

        /// <summary>
        /// The challenge starting date 
        /// </summary>
        /// <example>2021-08-20T08:00:00+01:00</example>
        [Required]
        public DateTime StartingDate { get; set; }
        /// <summary>
        /// The challenge ending date 
        /// </summary>
        /// <example>2021-08-20T08:00:00+01:00</example>
        [Required]
        public DateTime EndingDate { get; set; }
    }
}
