using BO_BusinessManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_BusinessManagement.Models.Mappers
{
    public static class MapperPayment
    {
        public static List<MPayment> MListPayment(this List<BoPayment> pListPayment)
        {
            var lListPayment = new List<MPayment>();
            pListPayment.ForEach(x => {
                var lPayment = new MPayment
                {
                    LCreationDate = x.LCreationDate,
                    LIdPayment = x.LIdPayment,
                    LModificationDate = x.LModificationDate,
                    LObject = new MObject
                    {
                        LIdObject = x.LObject.LIdObject,
                        LNameObject = x.LObject.LNameObject
                    },
                    LValuePayment = x.LValuePayment
                };
                lListPayment.Add(lPayment);
            });
            return lListPayment;
        }

        public static MPayment ToMPayment(this BoPayment pPayment)
        {
            return new MPayment
            {
                LCreationDate = pPayment.LCreationDate,
                LIdPayment = pPayment.LIdPayment,
                LMessageException = pPayment.LMessageDao,
                LModificationDate = pPayment.LModificationDate,
                LObject = new MObject
                {
                    LIdObject = pPayment.LObject.LIdObject,
                    LNameObject = pPayment.LObject.LNameObject
                },
                LOrder = new MOrder
                {
                    LIdOrder = pPayment.LOrder.LIdOrder,
                    LValueOrder = pPayment.LOrder.LValueOrder
                },
                LStatus = new MStatus
                {
                    LIdStatus = pPayment.LStatus.LIdStatus,
                    LDsEstado = pPayment.LStatus.LDsEstado
                },
                LValuePayment = pPayment.LValuePayment
            };
        }
    }
}