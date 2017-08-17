﻿using System;
using System.Collections.Generic;
using BO_BusinessManagement;
using System.Linq;
using System.Web;

namespace Project_BusinessManagement.Models
{
    public class MTaxe
    {
        private int lIdTaxe;
        private string lNameTaxe;
        private decimal lValueTaxe;
        private bool lIsPercent;
        private DateTime lCreationDate;
        private MStatus lStatus;
        private MObject lObject;

        public int LIdTaxe
        {
            get
            {
                return lIdTaxe;
            }

            set
            {
                lIdTaxe = value;
            }
        }

        public string LNameTaxe
        {
            get
            {
                return lNameTaxe;
            }

            set
            {
                lNameTaxe = value;
            }
        }

        public decimal LValueTaxe
        {
            get
            {
                return lValueTaxe;
            }

            set
            {
                lValueTaxe = value;
            }
        }

        public bool LIsPercent
        {
            get
            {
                return lIsPercent;
            }

            set
            {
                lIsPercent = value;
            }
        }

        public DateTime LCreationDate
        {
            get
            {
                return lCreationDate;
            }

            set
            {
                lCreationDate = value;
            }
        }

        public MStatus LStatus
        {
            get
            {
                return lStatus;
            }

            set
            {
                lStatus = value;
            }
        }

        public MObject LObject
        {
            get
            {
                return lObject;
            }

            set
            {
                lObject = value;
            }
        }

        public static List<MTaxe> MListAllTaxesXProduct(List<Bo_Taxe> oListTaxe)
        {
            List<MTaxe> oMListTaxe = new List<MTaxe>();
            oListTaxe.ForEach(x => {
                MTaxe lTaxe = new MTaxe();
                lTaxe.LStatus = new MStatus();
                lTaxe.lObject = new MObject();
                lTaxe.LIdTaxe = x.LIdTaxe;
                lTaxe.lNameTaxe = x.LNameTaxe;
                lTaxe.LIsPercent = x.LIsPercent;
                lTaxe.LValueTaxe = x.LValueTaxe;
                lTaxe.LStatus.LIdStatus = x.LStatus.LIdStatus;
                lTaxe.lObject.LIdObject = x.LObject.LIdObject;
                oMListTaxe.Add(lTaxe);
            });
            return oMListTaxe;
        }
    }
}