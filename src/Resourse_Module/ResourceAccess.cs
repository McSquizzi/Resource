using Resourse_Module.Resources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Threading.Tasks;

namespace Resourse_Module
{
    public class ResourceAccess : IResourseAccess
    {
        private ResourceManager _resourceManager;
        private Type _resourceType;
        private CultureInfo _defaultCulture = new CultureInfo("en-US");
        private CultureInfo _currentCulture;
        private Dictionary<string, string> _resource;
        public IDictionary<string, string> Resources
        {
            get
            {
                if (_resource.Keys.Count == 0)
                    GetResourceProperties();
                return _resource;
            }
        }
        public Type ResourceType
        {
            get
            {
                return _resourceType;
            }
            set
            {
                _resourceType = value;
                GetResourceProperties();
            }
        }
        public CultureInfo CurrentCulture
        {
            get
            {
                return _currentCulture;
            }
            set
            {
                _currentCulture = value;
                GetResourceProperties();
            }
        }

        private ResourceAccess()
        {
            _resource = new Dictionary<string, string>();
        }

        /// <summary>
        /// Initialize new instance of the ResourceAccess class
        /// </summary>
        /// <param name="resourceType"></param>
        public ResourceAccess(Type resourceType) : this()
        {
            _resourceType = resourceType;
            ResourceManagerInit(_resourceType);
        }

        /// <summary>
        /// Create new manager to work with resource
        /// </summary>
        private void ResourceManagerInit(Type resourceType)
        {
            _resourceManager = new ResourceManager(resourceType);
        }

        /// <summary>
        /// Get properties from resource file
        /// </summary>
        private void GetResourceProperties()
        {

            PropertyInfo[] resourceProperty = ResourceType.GetProperties();

            foreach (var property in resourceProperty)
            {
                if (property.PropertyType == typeof(string))
                {
                    _resource.Add(property.Name, _resourceManager.GetString(property.Name,
                        CurrentCulture != null ? CurrentCulture : _defaultCulture));
                }
            }
        }
    }
}
