using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuthentiTrack.UI.Helpers
{
    /// <summary>
    /// Class used to trim leading and trailing spaces for all string values
    /// </summary>
    public class TrimModelBinder : DefaultModelBinder
    {
        protected override void SetProperty(ControllerContext controllerContext,
          ModelBindingContext bindingContext,
          System.ComponentModel.PropertyDescriptor propertyDescriptor, object value)
        {
            object valueLocal = value;
            if (propertyDescriptor.PropertyType == typeof(string))
            {
                var stringValue = (string)valueLocal;
                if (!string.IsNullOrEmpty(stringValue))
                    stringValue = stringValue.Trim();

                valueLocal = stringValue;
            }

            base.SetProperty(controllerContext, bindingContext,
                                propertyDescriptor, valueLocal);
        }
    }
}