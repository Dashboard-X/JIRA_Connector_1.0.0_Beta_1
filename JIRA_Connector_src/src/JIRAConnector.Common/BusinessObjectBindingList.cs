using System;
using System.ComponentModel;
using System.Reflection;

namespace JIRAConnector.Common{
    public class BusinessObjectBindingList<T>: BindingList<T>{
        
        public BusinessObjectBindingList(){
            //this.AllowEdit = this.AllowNew = this.AllowRemove = false;
        }

        protected override void ApplySortCore(PropertyDescriptor prop, ListSortDirection direction){
            PropertyInfo sortingProp = typeof(T).GetProperty(prop.Name);
            if (typeof(IComparable).IsAssignableFrom(sortingProp.PropertyType)){
                // The type is an IComparable and so we can compare
                for (int i = this.Count - 1; i > 0; i--){
                    for (int j = 0; j < i; j++){
                        // Compare the properties of the objects
                        object lhs = sortingProp.GetValue(this[j], null);
                        object rhs = sortingProp.GetValue(this[j + 1], null);
                        // If ascending, compare left to right, otherwise compare right to left
                        if ((direction == ListSortDirection.Ascending && ((IComparable)lhs).CompareTo(rhs) > 0)
                            || (direction == ListSortDirection.Descending && ((IComparable)rhs).CompareTo(lhs) > 0))
                        {
                            T temp = this[j];
                            this[j] = this[j + 1];
                            this[j + 1] = temp;
                        }
                    }
                }
            }
        }

        protected override bool SupportsSortingCore{
            get { return true; }
        }
    }
}
