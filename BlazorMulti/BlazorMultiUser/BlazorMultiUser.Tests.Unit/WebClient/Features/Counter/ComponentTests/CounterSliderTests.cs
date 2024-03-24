using System.Reflection;
using BlazorMultiUser.Web.Client.Features.Counter.Components;
using Bunit;
using Microsoft.AspNetCore.Components;
using Xunit.Sdk;

namespace BlazorMultiUser.Tests.Unit.WebClient.Features.Counter.ComponentTests;

public class CounterSliderTests
{
    public class CounterSliderTest
    {
        [Fact]
        public void NoParametersRendersCorrectly()
        {
            using var ctx = new TestContext();

            var cut = ctx.RenderComponent<CounterSlider>();

            cut.MarkupMatches(
                GetExpectedMarkupFromEmbeddedResource(
                    $"{GetType().Namespace}.{nameof(NoParametersRendersCorrectly)}.html"));
        }

        [Fact]
        public void DisabledRendersCorrectly()
        {
            using var ctx = new TestContext();

            var cut = ctx.RenderComponent<CounterSlider>(builder => { builder.Add(p => p.Disabled, true); });

            cut.MarkupMatches(
                GetExpectedMarkupFromEmbeddedResource(
                    $"{GetType().Namespace}.{nameof(DisabledRendersCorrectly)}.html"));
        }


        [Fact]
        public void DefaultValueWhenNoDebounceRendersInstantly()
        {
            using var ctx = new TestContext();

            var cut = ctx.RenderComponent<CounterSlider>(builder =>
            {
                builder.Add(p => p.Value, 50);
                builder.Add(p => p.Debounce, false);
            });

            cut.MarkupMatches(
                GetExpectedMarkupFromEmbeddedResource(
                    $"{GetType().Namespace}.{nameof(DefaultValueWhenNoDebounceRendersInstantly)}.html"));
        }

        [Fact]
        public void DefaultValueWhenDebounceRendersInstantly()
        {
            using var ctx = new TestContext();

            var cut = ctx.RenderComponent<CounterSlider>(builder =>
            {
                builder.Add(p => p.Value, 50);
                builder.Add(p => p.Debounce, true);
            });

            cut.MarkupMatches(
                GetExpectedMarkupFromEmbeddedResource(
                    $"{GetType().Namespace}.{nameof(DefaultValueWhenDebounceRendersInstantly)}.html"));
        }

        [Fact]
        public void ValueChangeWhenNoDebounceRendersInstantly()
        {
            using var ctx = new TestContext();

            var cut = ctx.RenderComponent<CounterSlider>(builder =>
            {
                builder.Add(p => p.Value, 50);
                builder.Add(p => p.Debounce, false);
            });
            var inputElement = cut.Find("input");
            inputElement.Change("75");

            cut.MarkupMatches(
                GetExpectedMarkupFromEmbeddedResource(
                    $"{GetType().Namespace}.{nameof(ValueChangeWhenNoDebounceRendersInstantly)}.html"));
        }

        [Fact]
        public async Task ValueChangeWhenDebounceRendersAfterInterval()
        {
            using var ctx = new TestContext();

            var valueChangedCalled = false;
            var valueChangedValue = 0;
            var valueChangedCallback = EventCallback.Factory.Create<int>(this, value =>
            {
                valueChangedCalled = true;
                valueChangedValue = value;
            });

            var cut = ctx.RenderComponent<CounterSlider>(builder =>
            {
                builder.Add(p => p.Value, 50);
                builder.Add(p => p.Debounce, true);
                builder.Add(p => p.DebounceMilliseconds, 50);
                builder.Add(p => p.ValueChanged, valueChangedCallback);
            });

            var inputElement = cut.Find("input");
            inputElement.Change("75");

            cut.MarkupMatches(
                GetExpectedMarkupFromEmbeddedResource(
                    $"{GetType().Namespace}.{nameof(ValueChangeWhenDebounceRendersAfterInterval)}.html"));

            Assert.False(valueChangedCalled);
            Assert.Equal(0, valueChangedValue);

            await Task.Delay(51);

            Assert.True(valueChangedCalled);
            Assert.Equal(75, valueChangedValue);
        }


        private string GetExpectedMarkupFromEmbeddedResource(string path)
        {
            var assembly = Assembly.GetExecutingAssembly();
            using var stream = assembly.GetManifestResourceStream(path);
            if (stream == null) throw new XunitException($"Resource '{path}' not found.");
            using var reader = new StreamReader(stream);
            var expectedMarkup = reader.ReadToEnd();
            return expectedMarkup;
        }
    }
}