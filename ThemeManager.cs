using MaterialSkin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RKS_Inventory
{
    public class ThemeManager
    {
        private static ThemeManager _instance;
        private MaterialSkinManager _materialSkinManager;

        private ThemeManager()
        {
            _materialSkinManager = MaterialSkinManager.Instance;
        }

        public static ThemeManager Instance => _instance ?? (_instance = new ThemeManager());

        public MaterialSkinManager TheMaterialSkinManager => _materialSkinManager;

        public void SetTheme(MaterialSkinManager.Themes theme)
        {
            _materialSkinManager.Theme = theme;
            foreach (Form form in Application.OpenForms)
            {
                _materialSkinManager.AddFormToManage((MaterialSkin.Controls.MaterialForm)form);
            }
            foreach (Form form in Application.OpenForms)
            {
                form.Invalidate();
            }
        }
    }
}
