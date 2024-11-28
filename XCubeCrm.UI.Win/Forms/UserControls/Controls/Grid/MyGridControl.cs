using DevExpress.Data; // Add this using directive at the top of your file

using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Registrator;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCubeCrm.UI.Win.Functions;
using XCubeCrm.UI.Win.Interfaces;


namespace XCubeCrm.UI.Win.Forms.UserControls.Controls.Grid
{
    [ToolboxItem(true)]
    public class MyGridControl : GridControl
    {
        protected override BaseView CreateDefaultView()
        {
            var view = (GridView)CreateView("MyGridView");

            view.Appearance.ViewCaption.ForeColor = Color.Maroon;
            view.Appearance.HeaderPanel.ForeColor = Color.Maroon;
            view.Appearance.HeaderPanel.TextOptions.HAlignment = HorzAlignment.Center;
            view.Appearance.FooterPanel.ForeColor = Color.Maroon;
            view.Appearance.FooterPanel.Font = new Font(new FontFamily("Tahoma"), 8.25f, FontStyle.Bold);

            // Menü ayarları
            view.OptionsMenu.EnableColumnMenu = true;  // true yapıldı
            view.OptionsMenu.EnableFooterMenu = true;
            view.OptionsMenu.EnableGroupPanelMenu = true;
            view.OptionsMenu.ShowFooterItem = true;
            view.OptionsMenu.ShowGroupSummaryEditorItem = true;
            view.OptionsMenu.ShowSummaryItemMode = DefaultBoolean.True;

            // Gruplama ayarları
            view.OptionsView.ShowGroupPanel = true;  // true yapıldı
            view.GroupPanelText = "Gruplamak istediğiniz kolonu buraya sürükleyin";
            view.OptionsCustomization.AllowGroup = true;

            // Diğer ayarlar
            view.OptionsNavigation.EnterMoveNextColumn = true;
            view.OptionsPrint.AutoWidth = false;
            view.OptionsPrint.PrintFooter = false;
            view.OptionsPrint.PrintGroupFooter = false;
            view.OptionsView.ShowViewCaption = true;
            view.OptionsView.ShowAutoFilterRow = true;
            view.OptionsView.ColumnAutoWidth = false;
            view.OptionsView.RowAutoHeight = true;
            view.OptionsView.HeaderFilterButtonShowMode = FilterButtonShowMode.Button;
            view.FocusRectStyle = DrawFocusRectStyle.RowFocus;

            // Kolonlar
            var idColumn = new MyGridColumn();
            idColumn.Caption = "Id";
            idColumn.FieldName = "Id";
            idColumn.OptionsColumn.AllowEdit = false;
            idColumn.OptionsColumn.ShowInCustomizationForm = false;
            view.Columns.Add(idColumn);

            var kodColumn = new MyGridColumn();
            kodColumn.Caption = "Kod";
            kodColumn.FieldName = "Kod";
            kodColumn.Visible = true;
            kodColumn.OptionsColumn.AllowEdit = false;
            kodColumn.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
            kodColumn.AppearanceCell.Options.UseTextOptions = true;
            view.Columns.Add(kodColumn);

            return view;
        }
        protected override void RegisterAvailableViewsCore(InfoCollection collection)
        {
            base.RegisterAvailableViewsCore(collection);
            collection.Add(new MyGridInfoRegistrator());
        }
        private class MyGridInfoRegistrator : GridInfoRegistrator
        {
            public override string ViewName => "MyGridView";
            public override BaseView CreateView(GridControl grid) => new MyGridView(grid);
        }
    }
    public class MyGridView : GridView, IStatusBarKisayol
    {
        #region Properties
        public string StatusBarKisayol { get; set; }
        public string StatusBarKisayolAciklama { get; set; }
        public string StatusBarAciklama { get; set; }
        #endregion
        public MyGridView() { }

        public MyGridView(GridControl ownerGrid) : base(ownerGrid)
        {
            // Görünüm ayarları
            Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            Appearance.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            Appearance.Row.Options.UseTextOptions = true;

            // Menü ve gruplama ayarları
            OptionsMenu.ShowGroupSortSummaryItems = true;
            OptionsMenu.ShowGroupSummaryEditorItem = true;
            OptionsMenu.ShowSummaryItemMode = DefaultBoolean.True;
            OptionsMenu.ShowFooterItem = true;
            OptionsMenu.EnableColumnMenu = true;
            OptionsMenu.EnableFooterMenu = true;
            OptionsMenu.EnableGroupPanelMenu = true;

            // Gruplama ayarları
            OptionsView.ShowGroupPanel = true;
            OptionsView.GroupFooterShowMode = GroupFooterShowMode.VisibleAlways;
            GroupPanelText = "Gruplamak istediğiniz kolonu buraya sürükleyin";
            OptionsCustomization.AllowGroup = true;
            OptionsView.ShowGroupedColumns = true;

            // Footer ayarları
            OptionsView.ShowFooter = true;

            // Grup özeti için event
            GroupRowExpanded += MyGridView_GroupRowExpanded;

            // Diğer ayarlar
            OptionsView.BestFitMode = GridBestFitMode.Fast;
            VertScrollVisibility = ScrollVisibility.Auto;
        }
        private void MyGridView_GroupRowExpanded(object sender, DevExpress.XtraGrid.Views.Base.RowEventArgs e)
        {
            try
            {
                var view = sender as GridView;
                if (view == null) return;

                foreach (GridColumn column in view.Columns)
                {
                    if (column.ColumnType == typeof(decimal) ||
                        column.ColumnType == typeof(double) ||
                        column.ColumnType == typeof(int))
                    {
                        // Önce mevcut özetleri temizle
                        var existingSummaries = view.GroupSummary
                            .Where(x => x.FieldName == column.FieldName)
                            .ToList();

                        foreach (var summary in existingSummaries)
                        {
                            view.GroupSummary.Remove(summary);
                        }

                        // Yeni özetleri ekle
                        view.GroupSummary.AddRange(new[]
                        {
                    new GridGroupSummaryItem
                    {
                        FieldName = column.FieldName,
                        SummaryType = SummaryItemType.Sum,
                        DisplayFormat = "Toplam={0:n2}",
                        ShowInGroupColumnFooter = column
                    },
                    new GridGroupSummaryItem
                    {
                        FieldName = column.FieldName,
                        SummaryType = SummaryItemType.Count,
                        DisplayFormat = "Adet={0}",
                        ShowInGroupColumnFooter = column
                    },
                    new GridGroupSummaryItem
                    {
                        FieldName = column.FieldName,
                        SummaryType = SummaryItemType.Average,
                        DisplayFormat = "Ort={0:n2}",
                        ShowInGroupColumnFooter = column
                    }
                });
                    }
                }

                // Grid'i yenile
                if (view.GridControl != null)
                {
                    view.GridControl.BeginInvoke(new Action(() =>
                    {
                        view.LayoutChanged();
                        view.RefreshData();
                    }));
                }
            }
            catch (Exception ex)
            {
                // Hata durumunda loglama yapabilirsiniz
            }
        }
        private void MyGridView_GroupRowExpanding(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            EnsureGroupSummaries();
        }

        private void MyGridView_GroupRowCollapsing(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            EnsureGroupSummaries();
        }

        private void EnsureGroupSummaries()
        {
            foreach (GridColumn column in Columns)
            {
                if (column.UnboundType == UnboundColumnType.Decimal ||
                    column.ColumnType == typeof(decimal) ||
                    column.ColumnType == typeof(double) ||
                    column.ColumnType == typeof(float) ||
                    column.ColumnType == typeof(int))
                {
                    if (!GroupSummary.Any(s => s.FieldName == column.FieldName))
                    {
                        // Toplam
                        GroupSummary.Add(new GridGroupSummaryItem
                        {
                            FieldName = column.FieldName,
                            SummaryType = SummaryItemType.Sum,
                            DisplayFormat = "Toplam: {0:n2}",
                            ShowInGroupColumnFooter = column
                        });

                        // Adet
                        GroupSummary.Add(new GridGroupSummaryItem
                        {
                            FieldName = column.FieldName,
                            SummaryType = SummaryItemType.Count,
                            DisplayFormat = "Adet: {0}",
                            ShowInGroupColumnFooter = column
                        });

                        // Ortalama
                        GroupSummary.Add(new GridGroupSummaryItem
                        {
                            FieldName = column.FieldName,
                            SummaryType = SummaryItemType.Average,
                            DisplayFormat = "Ort: {0:n2}",
                            ShowInGroupColumnFooter = column
                        });

                        // Maksimum
                        GroupSummary.Add(new GridGroupSummaryItem
                        {
                            FieldName = column.FieldName,
                            SummaryType = SummaryItemType.Max,
                            DisplayFormat = "Maks: {0:n2}",
                            ShowInGroupColumnFooter = column
                        });

                        // Minimum
                        GroupSummary.Add(new GridGroupSummaryItem
                        {
                            FieldName = column.FieldName,
                            SummaryType = SummaryItemType.Min,
                            DisplayFormat = "Min: {0:n2}",
                            ShowInGroupColumnFooter = column
                        });
                    }
                }
            }

            LayoutChanged();
        }

        private void MyGridView_CustomDrawGroupRow(object sender, DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs e)
        {
            var view = sender as GridView;
            if (view == null) return;

            foreach (GridColumn column in view.Columns)
            {
                if (column.ColumnType == typeof(decimal) ||
                    column.ColumnType == typeof(double) ||
                    column.ColumnType == typeof(int) ||
                    column.ColumnType == typeof(float))
                {
                    // Toplam
                    if (!view.GroupSummary.Any(x => x.FieldName == column.FieldName &&
                                                  (SummaryItemType)x.SummaryType == SummaryItemType.Sum))
                    {
                        view.GroupSummary.Add(new GridGroupSummaryItem
                        {
                            FieldName = column.FieldName,
                            ShowInGroupColumnFooter = column,
                            SummaryType = DevExpress.Data.SummaryItemType.Sum,
                            DisplayFormat = "Toplam={0:n2}"
                        });
                    }

                    // Adet
                    if (!view.GroupSummary.Any(x => x.FieldName == column.FieldName &&
                                                  (SummaryItemType)x.SummaryType == SummaryItemType.Count))
                    {
                        view.GroupSummary.Add(new GridGroupSummaryItem
                        {
                            FieldName = column.FieldName,
                            ShowInGroupColumnFooter = column,
                            SummaryType = DevExpress.Data.SummaryItemType.Count,
                            DisplayFormat = "Adet={0}"
                        });
                    }

                    // Ortalama
                    if (!view.GroupSummary.Any(x => x.FieldName == column.FieldName &&
                                                  (SummaryItemType)x.SummaryType == SummaryItemType.Average))
                    {
                        view.GroupSummary.Add(new GridGroupSummaryItem
                        {
                            FieldName = column.FieldName,
                            ShowInGroupColumnFooter = column,
                            SummaryType = DevExpress.Data.SummaryItemType.Average,
                            DisplayFormat = "Ort={0:n2}"
                        });
                    }
                }
            }
        }




        protected override void OnColumnChangedCore(GridColumn column)
        {
            base.OnColumnChangedCore(column);

            if (column.ColumnEdit == null) return;
            if (column.ColumnEdit.GetType() == typeof(RepositoryItemDateEdit))
            {
                column.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                ((RepositoryItemDateEdit)column.ColumnEdit).Mask.MaskType = MaskType.DateTimeAdvancingCaret;
            }
        }
        protected override GridColumnCollection CreateColumnCollection()
        {
            return new MyGridColumnCollection(this);
        }

        private class MyGridColumnCollection : GridColumnCollection
        {
            public MyGridColumnCollection(ColumnView view) : base(view) { }
            protected override GridColumn CreateColumn()
            {
                var column = new MyGridColumn();
                column.OptionsColumn.AllowEdit = false;
                return column;
            }

        }
    }
    public class MyGridColumn : GridColumn, IStatusBarKisayol
    {
        #region Properties
        public string StatusBarKisayol { get; set; }
        public string StatusBarKisayolAciklama { get; set; }
        public string StatusBarAciklama { get; set; }
        #endregion
    }

}
