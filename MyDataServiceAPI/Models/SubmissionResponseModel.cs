using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MyDataServiceAPI.Models
{

    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class ResponseDoc
    {

        private ResponseDocResponse responseField;

        /// <remarks/>
        public ResponseDocResponse response
        {
            get
            {
                return this.responseField;
            }
            set
            {
                this.responseField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ResponseDocResponse
    {

        private byte indexField;

        private string invoiceUidField;

        private ulong invoiceMarkField;

        private ulong cancellationMarkField;

        private string statusCodeField;

        private ResponseDocResponseErrors errorsField;

        /// <remarks/>
        public byte index
        {
            get
            {
                return this.indexField;
            }
            set
            {
                this.indexField = value;
            }
        }

        /// <remarks/>
        public string invoiceUid
        {
            get
            {
                return this.invoiceUidField;
            }
            set
            {
                this.invoiceUidField = value;
            }
        }

        /// <remarks/>
        public ulong invoiceMark
        {
            get
            {
                return this.invoiceMarkField;
            }
            set
            {
                this.invoiceMarkField = value;
            }
        }

        /// <remarks/>
        public ulong cancellationMark
        {
            get
            {
                return this.cancellationMarkField;
            }
            set
            {
                this.cancellationMarkField = value;
            }
        }

        /// <remarks/>
        public string statusCode
        {
            get
            {
                return this.statusCodeField;
            }
            set
            {
                this.statusCodeField = value;
            }
        }

        /// <remarks/>
        public ResponseDocResponseErrors errors
        {
            get
            {
                return this.errorsField;
            }
            set
            {
                this.errorsField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ResponseDocResponseErrors
    {

        private ResponseDocResponseErrorsError errorField;

        /// <remarks/>
        public ResponseDocResponseErrorsError error
        {
            get
            {
                return this.errorField;
            }
            set
            {
                this.errorField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ResponseDocResponseErrorsError
    {

        private string messageField;

        private byte codeField;

        /// <remarks/>
        public string message
        {
            get
            {
                return this.messageField;
            }
            set
            {
                this.messageField = value;
            }
        }

        /// <remarks/>
        public byte code
        {
            get
            {
                return this.codeField;
            }
            set
            {
                this.codeField = value;
            }
        }
    }


}
