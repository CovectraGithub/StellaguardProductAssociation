using AuthentiTrack.UI.SerializationServiceReference;
using AuthentiTrack.UI.Areas.Serialization.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthentiTrack.UI.Helpers
{
    public partial class VMToDTOConverter
    {
        public EditDosageFormDTO GetEditDosageForm(EditSeedDosageViewModel dosageViewModel)
        {
            int dosageFormId = dosageViewModel.DosageFormId;
            string dosageForm = dosageViewModel.DosageForm;

            return new EditDosageFormDTO
            {
                DosageFormId = dosageFormId,
                DosageForm = dosageForm
            };
        }

        public AddDosageDTO GetAddDosageDTO(AddDosageViewModel addDosageViewModel)
        {
            string DosageForm = string.Empty;
            if(addDosageViewModel != null)
            {
                DosageForm = addDosageViewModel.DosageForm;
            }
            return new AddDosageDTO
            {
                DosageForm = DosageForm,
            };
        }
    }
}