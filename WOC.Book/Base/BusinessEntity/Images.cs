using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Woc.Book.Base.BusinessEntity
{
    [Serializable]
    public class Images : IBusinessEntity
    {
        private Guid m_ImageID;
        private string m_FileName;
        private byte[] m_ImageFile;
        private string m_ContentType;
        private int m_Filesize;
        private Guid m_CompanyID;

        public Guid ImageID
        {
            get { return m_ImageID; }
            set { m_ImageID = value; }
        }
        public string FileName
        {
            get { return m_FileName; }
            set { m_FileName = value; }
        }
        public byte[] ImageFile
        {
            get { return m_ImageFile; }
            set { m_ImageFile = value; }
        }
        public string ContentType
        {
            get { return m_ContentType; }
            set { m_ContentType = value; }
        }
        public int Filesize
        {
            get { return m_Filesize; }
            set { m_Filesize = value; }
        }
        public Guid CompanyID
        {
            get { return m_CompanyID; }
            set { m_CompanyID = value; }
        }

    }

}
