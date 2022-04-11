using Serilog;
using System;

namespace GameLibrary.UI
{
    public class Logger : Application.ILogger
    {
        private readonly Serilog.Core.Logger logger;

        public Logger() => this.logger = new LoggerConfiguration()
            .WriteTo.Debug()
            .WriteTo.File("game-library.log")
            .CreateLogger();

        public void Debug(string template) => this.logger.Debug(template);
        public void Debug(string template, params object?[] values) => this.logger.Debug(template, values);
        public void Debug(Exception ex, string template) => this.logger.Debug(ex, template);
        public void Debug(Exception ex, string template, params object?[] values) => this.logger.Debug(ex, template, values);

        public void Info(string template) => this.logger.Information(template);
        public void Info(string template, params object?[] values) => this.logger.Information(template, values);
        public void Info(Exception ex, string template) => this.logger.Information(ex, template);
        public void Info(Exception ex, string template, params object?[] values) => this.logger.Information(ex, template, values);

        public void Warn(string template) => this.logger.Warning(template);
        public void Warn(string template, params object?[] values) => this.logger.Warning(template, values);
        public void Warn(Exception ex, string template) => this.logger.Warning(ex, template);
        public void Warn(Exception ex, string template, params object?[] values) => this.logger.Warning(ex, template, values);

        public void Error(string template) => this.logger.Error(template);
        public void Error(string template, params object?[] values) => this.logger.Error(template, values);
        public void Error(Exception ex, string template) => this.logger.Error(ex, template);
        public void Error(Exception ex, string template, params object?[] values) => this.logger.Error(ex, template, values);
    }
}