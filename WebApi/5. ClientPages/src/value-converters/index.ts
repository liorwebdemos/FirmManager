import { FrameworkConfiguration } from "aurelia-framework";
import { PLATFORM } from "aurelia-pal";

export function configure(config: FrameworkConfiguration): void
{
  config.globalResources([
    PLATFORM.moduleName("./to-formatted-number"),
    PLATFORM.moduleName("./to-date-format"),
    PLATFORM.moduleName("./to-title-case")
  ]);
}
