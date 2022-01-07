using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Woc.Book.Base.BusinessEntity;
using Woc.Book.Base.Service;
using System.Data;

namespace Woc.Book.Base
{
    public class ImageController
    {
        public String SaveImage(IBusinessEntity iBusinessEntity)
        {
            ImageService imageService = new ImageService();
            return imageService.SaveImage(iBusinessEntity);
        }

        public DataTable GetImage(Guid companyID)
        {
            ImageService imageService = new ImageService();
            return imageService.GetImage(companyID);
        }

        public byte[] GetImageBinary(Guid companyID)
        {
            ImageService imageService = new ImageService();
            return imageService.GetImageBinary(companyID);
        }

        public String UpdateImage(IBusinessEntity iBusinessEntity)
        {
            ImageService imageService = new ImageService();
            return imageService.UpdateImage(iBusinessEntity);
        }
    }
}
