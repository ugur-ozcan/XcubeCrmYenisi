using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.ComponentModel;
using System.Drawing;
using XCubeCrm.UI.Win.Interfaces;
 

namespace XCubeCrm.UI.Win.Forms.UserControls.Controls
{
    [ToolboxItem(true)]
    public class MyButtonEdit : ButtonEdit, IStatusBarKisayol
    {
        [ToolboxItem(true)]
       
        public MyButtonEdit()
        {
            Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            Properties.AppearanceFocused.BackColor = Color.LightCyan;
        }

        public override bool EnterMoveNextControl { get  ; set ; } = true;
        #region Events
        //public  long? Id { get; set; }
        private long? _id;
        [Browsable(false)]
        public long? Id
        {
            get => _id;
            set
            {
                var oldValue = _id;
                var newValue = value;
                if (oldValue == newValue) return;

                _id = value;

                IdChanged?.Invoke(this, new IdChangedEventsArgs(oldValue, newValue));
                EnabledChange(this,EventArgs.Empty);
            }
        } 
        #endregion

        public string StatusBarAciklama { get; set; }
        public string StatusBarKisayol { get; set; } = "F4 : ";
        public string StatusBarKisayolAciklama { get; set; }

        public event EventHandler<IdChangedEventsArgs> IdChanged  ;
        public event EventHandler EnabledChange = delegate { };

    }
    public class IdChangedEventsArgs:EventArgs 
    {
        public IdChangedEventsArgs(long? oldValue,long? newValue)
        {
            OldValue = oldValue;
            NewValue = newValue;
        }
        public long? OldValue { get; }
        public long? NewValue { get; }
    }
}
