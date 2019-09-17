using System;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace Tida.Xml {
    /// <summary>
    /// 针对<see cref="System.Xml.Linq"/>的拓展;
    /// </summary>
    public static class XmlExtensions {
        /// <summary>
        /// 从Xelem中获得值;
        /// </summary>
        /// <param name="elemName"></param>
        /// <returns></returns>
        public static string GetXElemValue(this XElement xElem, [CallerMemberName]string elemName = null) {
            var labelElem = xElem.Element(elemName);
            return labelElem?.Value;
        }

        /// <summary>
        /// 设定Xelem中
        /// </summary>
        /// <param name="value"></param>
        /// <param name="elemName"></param>
        public static void SetXElemValue(this XElement xElem, object value, [CallerMemberName]string elemName = null) {
            var labelElem = GetOrCreateXElem(xElem, elemName);
            labelElem.Value = value?.ToString() ?? string.Empty;
        }

        /// <summary>
        /// 获得本地子元素(若无则创建)
        /// </summary>
        /// <param name="elemName"></param>
        /// <returns></returns>
        public static XElement GetOrCreateXElem(this XElement xElem, [CallerMemberName]string elemName = null) {
            var labelElem = xElem.Element(elemName);
            //若不存在label元素,则新建之;
            if (labelElem == null) {
                labelElem = new XElement(XName.Get(elemName));
                xElem.Add(labelElem);
            }
            return labelElem;
        }

        /// <summary>
        /// 获得属性组单元;
        /// </summary>
        /// <param name="xElem"></param>
        /// <param name="groupName"></param>
        /// <returns></returns>
        public static XItemsGroup GetGroup(this XElement xElem, string groupName = null) {
            var groupElem = xElem.Element(groupName);
            if (groupElem == null) {
                groupElem = new XElement(groupName);
                xElem.Add(groupElem);
            }

            return new XItemsGroup(groupElem);
        }

        //得到某个Elem值;
        public static string GetXElemValue(this XDocument xDoc, [CallerMemberName]string elemName = null) {
            if (xDoc == null) {
                throw new ArgumentNullException(nameof(xDoc));
            }

            return xDoc.Root?.Element(elemName)?.Value;
        }

        //设定某个Elem值;
        public static void SetXElemValue(this XDocument xDoc, string value, [CallerMemberName]string elemName = null) {
            if (xDoc == null) {
                throw new ArgumentNullException(nameof(xDoc));
            }

            var rootElem = xDoc?.Root;
            if (rootElem != null) {
                var labelElem = rootElem.Element(elemName);
                //若不存在label文件名,则新建之;
                if (labelElem == null) {
                    labelElem = new XElement(XName.Get(elemName));
                    rootElem.Add(labelElem);
                }
                labelElem.Value = value ?? string.Empty;
            }
        }
    }


    /// <summary>
    /////XElem的子元素组属性;
    /// </summary>
    /// <example>
    ///     <PropertyItems>
    ///         <OSVersion>Windows10</OSVersion>
    ///         <MemoryCap>8 * 1024 * 1024 * 1024</MemoryCap>
    ///     </PropertyItems>
    /// </example>
    public class XItemsGroup {
        public XItemsGroup(XElement elem) {
            if(elem == null) {
                throw new ArgumentNullException(nameof(elem));
            }
            _elem = elem;
        }

        private XElement _elem;
        public string this[string itemName] {
            get {
                var itemElem = _elem.Element(itemName);
                if (itemElem == null) {
                    itemElem = new XElement(itemElem);
                    _elem.Add(itemElem);
                }

                return itemElem.Value;
            }
            set {
                var itemElem = _elem.Element(itemName);
                if (itemElem == null) {
                    itemElem = new XElement(itemName);
                    _elem.Add(itemElem);
                }

                itemElem.Value = value;
            }
        }

        public XElement CreateElem(string elemName) {
            var elem = new XElement(elemName);
            _elem.Add(elem);
            return elem;
        }
    }

}
