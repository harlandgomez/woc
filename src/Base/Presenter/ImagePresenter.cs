using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Woc.Book.Base;
using Woc.Book.Base.BusinessEntity;
using System.Data;

namespace Woc.Book.Base.Presenter
{
    public class ImagePresenter
    {
        ImageController imageController;

        public String SaveImage(IBusinessEntity iBusinessEntity)
        {
            imageController = new ImageController();
            return imageController.SaveImage(iBusinessEntity);
        }

        public DataTable GetImage(Guid companyID)
        {
            imageController = new ImageController();
            return imageController.GetImage(companyID);
        }

        public String UpdateImage(IBusinessEntity iBusinessEntity)
        {
            imageController = new ImageController();
            return imageController.UpdateImage(iBusinessEntity);
        }
    }
}
