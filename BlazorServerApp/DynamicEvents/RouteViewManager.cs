using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServerApp.DynamicEvents
{
    public class RouteViewManager
    {
        bool _RenderEventQueued;

        public async Task SetParametersAsync(ParameterView parameters)
        {
            // Sets the component parameters
            parameters.SetParameterProperties(this);
            // Check if we have either RouteData or ViewData
            if (RouteData == null)
            {
                throw new InvalidOperationException($"The {nameof(RouteView)} component requires a non - null value for the parameter { nameof(RouteData)}.");
            }
            // we've routed and need to clear the ViewData
            this._ViewData = null;
            // Render the component
            await this.RenderAsync();
        }

        public async Task RenderAsync() => await InvokeAsync(() =>
        {
            if (!this._RenderEventQueued)
            {
                this._RenderEventQueued = true;
                _renderHandle.Render(_renderDelegate);
            }
        }
        );

        protected Task InvokeAsync(Action workItem) => _renderHandle.Dispatcher.InvokeAsync(workItem);

        private RenderFragment _renderDelegate => builder =>
        {
            // We're being executed so no longer queued
            _RenderEventQueued = false;
            // Adds cascadingvalue for the ViewManager
            builder.OpenComponent<CascadingValue<RouteViewManager>>(0);
            builder.AddAttribute(1, "Value", this);
            // Get the layout render fragment
            builder.AddAttribute(2, "ChildContent", this._layoutViewFragment);
            builder.CloseComponent();
        };

        private RenderFragment _layoutViewFragment => builder =>
        {
            Type _pageLayoutType =
                RouteData?.PageType.GetCustomAttribute<LayoutAttribute>()?.LayoutType
                ?? RouteViewService.Layout
                ?? DefaultLayout;

            builder.OpenComponent<LayoutView>(0);
            builder.AddAttribute(1, nameof(LayoutView.Layout), _pageLayoutType);
            builder.AddAttribute(2, nameof(LayoutView.ChildContent), _renderComponentWithParameters);
            builder.CloseComponent();
        };

        private RenderFragment _renderComponentWithParameters => builder =>
        {
            Type componentType = null;
            IReadOnlyDictionary<string, object> parameters = new Dictionary<string, object>();

            if (_ViewData != null)
            {
                componentType = _ViewData.ViewType;
                parameters = _ViewData.ViewParameters;
            }
            else if (RouteData != null)
            {
                componentType = RouteData.PageType;
                parameters = RouteData.RouteValues;
            }

            if (componentType != null)
            {
                builder.OpenComponent(0, componentType);
                foreach (var kvp in parameters)
                {
                    builder.AddAttribute(1, kvp.Key, kvp.Value);
                }
                builder.CloseComponent();
            }
            else
            {
                builder.OpenElement(0, "div");
                builder.AddContent(1, "No Route or View Configured to Display");
                builder.CloseElement();
            }
        };
    }
}
