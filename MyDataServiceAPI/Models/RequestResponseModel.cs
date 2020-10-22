using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDataServiceAPI.Models
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.aade.gr/myDATA/invoice/v1.0")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.aade.gr/myDATA/invoice/v1.0", IsNullable = false)]
    public partial class RequestedDoc
    {

        private continuationTokenType continuationTokenField;

        private RequestedDocInvoicesDoc invoicesDocField;

        private RequestedDocCancelledInvoicesDoc cancelledInvoicesDocField;

        private RequestedDocIncomeClassificationsDoc incomeClassificationsDocField;

        private RequestedDocExpensesClassificationDoc expensesClassificationDocField;

        /// <remarks/>
        public continuationTokenType continuationToken
        {
            get
            {
                return this.continuationTokenField;
            }
            set
            {
                this.continuationTokenField = value;
            }
        }

        /// <remarks/>
        public RequestedDocInvoicesDoc invoicesDoc
        {
            get
            {
                return this.invoicesDocField;
            }
            set
            {
                this.invoicesDocField = value;
            }
        }

        /// <remarks/>
        public RequestedDocCancelledInvoicesDoc cancelledInvoicesDoc
        {
            get
            {
                return this.cancelledInvoicesDocField;
            }
            set
            {
                this.cancelledInvoicesDocField = value;
            }
        }

        /// <remarks/>
        public RequestedDocIncomeClassificationsDoc incomeClassificationsDoc
        {
            get
            {
                return this.incomeClassificationsDocField;
            }
            set
            {
                this.incomeClassificationsDocField = value;
            }
        }

        /// <remarks/>
        public RequestedDocExpensesClassificationDoc expensesClassificationDoc
        {
            get
            {
                return this.expensesClassificationDocField;
            }
            set
            {
                this.expensesClassificationDocField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.aade.gr/myDATA/invoice/v1.0")]
    public partial class continuationTokenType
    {

        private string nextPartitionKeyField;

        private string nextRowKeyField;

        /// <remarks/>
        public string nextPartitionKey
        {
            get
            {
                return this.nextPartitionKeyField;
            }
            set
            {
                this.nextPartitionKeyField = value;
            }
        }

        /// <remarks/>
        public string nextRowKey
        {
            get
            {
                return this.nextRowKeyField;
            }
            set
            {
                this.nextRowKeyField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.aade.gr/myDATA/invoice/v1.0")]
    public partial class RequestedDocInvoicesDoc
    {

        private AadeBookInvoiceType[] invoiceField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("invoice")]
        public AadeBookInvoiceType[] invoice
        {
            get
            {
                return this.invoiceField;
            }
            set
            {
                this.invoiceField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.aade.gr/myDATA/invoice/v1.0")]
    public partial class RequestedDocCancelledInvoicesDoc
    {

        private CancelledInvoiceType[] cancelledinvoiceField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("cancelledinvoice")]
        public CancelledInvoiceType[] cancelledinvoice
        {
            get
            {
                return this.cancelledinvoiceField;
            }
            set
            {
                this.cancelledinvoiceField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.aade.gr/myDATA/invoice/v1.0")]
    public partial class CancelledInvoiceType
    {

        private long invoiceMarkField;

        private long cancellationMarkField;

        private System.DateTime cancellationDateField;

        /// <remarks/>
        public long invoiceMark
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
        public long cancellationMark
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
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime cancellationDate
        {
            get
            {
                return this.cancellationDateField;
            }
            set
            {
                this.cancellationDateField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.aade.gr/myDATA/invoice/v1.0")]
    public partial class RequestedDocIncomeClassificationsDoc
    {

        private InvoiceIncomeClassificationType[] incomeInvoiceClassificationField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("incomeInvoiceClassification")]
        public InvoiceIncomeClassificationType[] incomeInvoiceClassification
        {
            get
            {
                return this.incomeInvoiceClassificationField;
            }
            set
            {
                this.incomeInvoiceClassificationField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.aade.gr/myDATA/invoice/v1.0")]
    public partial class RequestedDocExpensesClassificationDoc
    {

        private InvoiceExpensesClassificationType[] expensesInvoiceClassificationField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("expensesInvoiceClassification")]
        public InvoiceExpensesClassificationType[] expensesInvoiceClassification
        {
            get
            {
                return this.expensesInvoiceClassificationField;
            }
            set
            {
                this.expensesInvoiceClassificationField = value;
            }
        }
    }
}
