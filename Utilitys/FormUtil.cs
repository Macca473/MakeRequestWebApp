using MakeRequestWebApp.Controllers;
using MakeRequestWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MakeRequestWebApp.Utilitys
{
    public class FormUtil : RequestController
    {
        public void ConvPI(object Rq)
        {
            List<PropertyInfo> Props = Rq.GetType().GetProperties().ToList();

            List<PropertyInfo> ToReturn;

            foreach (PropertyInfo Prop in Props)
            {
                Console.WriteLine("PropertyType: " + Prop.ToString());
            }
        }

        public FormProp GetProperty(string propName, object Obj)
        {
            Console.WriteLine("Running GetProperty: " + propName);

            PropertyInfo propertyInfo;

            try
            {
                propertyInfo = Obj.GetType().GetProperty(propName);

                object OutOb = propertyInfo.GetValue(Obj);

                //Console.WriteLine("OutOb: " + OutOb + " | " + OutOb.GetType());

                if(OutOb == null)
                {
                    Console.WriteLine(propName + " is null");

                    return new FormProp(propName, " ");
                }
                else
                {
                    Console.WriteLine(propName + " is found");

                    return new FormProp(propName, OutOb);
                }
            } catch (Exception ex)
            {
                Console.WriteLine($"Something went wrong with Getting the {propName} | " + ex);

                return null;
            }
        }

        public bool ReqIDSub(string RequestID, HashSet<FormProp> EditedProps, out Request ThisReq)
        {
            if (RequestID == "" || RequestID == null)
            {
                Console.WriteLine("RequestID is empty");

                foreach (FormProp _prop in EditedProps)
                {
                    Console.WriteLine("isEdited: " + _prop.PropName + " " + _prop.Value);
                }

                if (CheckMinReq(EditedProps))
                {

                    MakeRequest(new MakeRequest(EditedProps));

                } else
                {

                }

                ThisReq = null;

                return false;
            }
            else
            {
                Console.WriteLine("RequestID is populated: " + RequestID);

                try
                {
                    ThisReq = GetRequest(Int32.Parse(RequestID));

                    return true;
                }
                catch (Exception x)
                {
                    Console.WriteLine("SubReqID Parse: " + x);

                    ThisReq = null;

                    return false;
                }
            }
        }

        public bool CheckMinReq(HashSet<FormProp> EditedProps)
        {
            string[] MinReq = { "OrganisationUnitID", "RequestDetail", "RequestorName" };

            int check = 0;

            foreach (FormProp prop in EditedProps)
            {
                if(MinReq.Any(x => prop.PropName.Contains(x)) && prop.Value.Length >= 1)
                {
                    check++;
                }
            }

            if (check >= 3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
