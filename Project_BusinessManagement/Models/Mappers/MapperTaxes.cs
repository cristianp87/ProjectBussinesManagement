using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BO_BusinessManagement;
using Project_BusinessManagement.Extensibles;

namespace Project_BusinessManagement.Models.Mappers
{
    public static class MapperTaxes
    {
        public static List<MTaxe> MListAllTaxesXProduct(this List<BoTaxe> oListTaxe, int? pIdProducto)
        {
            var lMListTaxe = new List<MTaxe>();

            oListTaxe.ForEach(x => {
                var lTaxe = new MTaxe
                {
                    LStatus = new MStatus { LIdStatus = x.LStatus.LIdStatus },
                    LObject = new MObject { LIdObject = x.LObject.LIdObject },
                    LIdTaxe = x.LIdTaxe,
                    LNameTaxe = x.LNameTaxe,
                    LIsPercent = x.LIsPercent,
                    LValueTaxe = x.LValueTaxe,
                    LIdProduct = pIdProducto == null ? 0 : Convert.ToInt32(pIdProducto),
                    LMessageException = null
                };
                lMListTaxe.Add(lTaxe);
            });

            if (!lMListTaxe.Any())
            {
                var lTaxe = new MTaxe
                {
                    LIdProduct = pIdProducto == null ? 0 : Convert.ToInt32(pIdProducto),
                    LNameTaxe = "N/A",
                    LIsPercent = false,
                    LValueTaxe = 0,
                    LMessageException = "No tiene Impuestos"
                };
                lMListTaxe.Add(lTaxe);
            }
            return lMListTaxe;
        }

        public static List<SelectListItem> MListTaxesWithSelect(this List<BoTaxe> pBoListTaxe, bool pWithStatus)
        {
            var lListSelectTaxes = new List<SelectListItem>();
            var lListItemSelect = new SelectListItem
            {
                Text = "Seleccione...",
                Value = "0"
            };
            lListSelectTaxes.Add(lListItemSelect);
            if (pWithStatus)
            {
                pBoListTaxe.ForEach(x => {
                    if (x.LStatus.LIdStatus.ValidateStatus())
                    {
                        var lListItem = new SelectListItem
                        {
                            Value = x.LIdTaxe.ToString(),
                            Text = x.LNameTaxe
                        };
                        lListSelectTaxes.Add(lListItem);
                    }                   
                });
            }
            else
            {
                pBoListTaxe.ForEach(x => {
                    var lListItem = new SelectListItem
                    {
                        Value = x.LIdTaxe.ToString(),
                        Text = x.LNameTaxe
                    };
                    lListSelectTaxes.Add(lListItem);
                });
            }
            
            return lListSelectTaxes;
        }

        public static MTaxe GetTaxeXProduct(this BoTaxe pTaxe, int pIdProduct)
        {
            var lTaxe = new MTaxe
            {
                LObject = new MObject
                {
                    LIdObject = pTaxe.LObject.LIdObject,
                    LNameObject = pTaxe.LObject.LNameObject
                },
                LStatus = new MStatus
                {
                    LIdStatus = pTaxe.LStatus.LIdStatus,
                    LDsEstado = pTaxe.LStatus.LDsEstado
                },
                LCreationDate = pTaxe.LCreationDate,
                LIdProduct = pIdProduct,
                LIdTaxe = pTaxe.LIdTaxe,
                LIsPercent = pTaxe.LIsPercent,
                LMessageException = pTaxe.LMessageDao,
                LNameTaxe = pTaxe.LNameTaxe,
                LValueTaxe = pTaxe.LValueTaxe
            };
            return lTaxe;
        }
    }
}