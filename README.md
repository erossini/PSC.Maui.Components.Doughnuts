[![Nuget](https://img.shields.io/nuget/v/PSC.Maui.Components.Doughnuts)](https://www.nuget.org/packages/PSC.Maui.Components.Doughnuts/)

# Wheel\Doughnuts component for MAUI

This component for MAUI can run for all platforms and the result is in the following screenshot:

![image](https://github.com/erossini/PSC.Maui.Components.Doughnuts/assets/9497415/0f283746-ba68-4cf9-a2fa-d5c2057f0b69)

## Bindable Properties/Events

| Type     | Property           | Description                                                                                                               | Default Value                 |
| -------- | ------------------ | ------------------------------------------------------------------------------------------------------------------------- | ----------------------------- |
| Property | InnerColor         | This is the colour of the background of the Wheel                                                                         |                               |
| Property | SweepAngle         | The angle to be selected/highlighted starting from `0`                                                                    |                               |
| Property | WheelColor         | The base colour of the Wheel/Doughnut                                                                                     |                               |
| Property | WheelSelectedColor | The colour of the selected/highlighted                                                                                    |                               |

For more documentation about this component, please refer to [PureSourceCode](https://www.puresourcecode.com/dotnet/maui/custom-control-for-maui-using-skiasharp/)

## Platforms

The following platforms are currently supported:

| Platform       | Supported          |
|----------------|--------------------|
| Android        | Yes                |
| iOS            | Yes                |
| Windows        | Yes                |
| MacCatalyst    | Yes                |

## Coming soon

### Slider

![-mauislider](https://github.com/erossini/PSC.Maui.Components.Doughnuts/assets/9497415/143aee37-8ad8-4985-a576-c6ca9e61aa50)

## Bindable Properties/Events

| Type     | Property           | Description                                                                                                               | Default Value                 |
| -------- | ------------------ | ------------------------------------------------------------------------------------------------------------------------- | ----------------------------- |
| Property | Arc                | How many degrees the slider should take up from the start (Max 360 - a full circle)                                       | `360`                         |
| Property | KnobColor          | The colour of the knob/handle of the slider                                                                               | `Color.FromArgb("#ffff0000")` |
| Property | KnobWidth          | The width of the knob/handle of the slider                                                                                | `5`                           |
| Property | Maximum            | The maximum value of the slider.                                                                                          | `1`                           |
| Property | Minimum            | The minimum value of the slider.                                                                                          | `0`                           |
| Property | PaddingAround      | Spacing from the edges of the control.                                                                                    | `25`                          |
| Property | Start              | The `Start` of the slider is in degrees (0 degrees is on the right side of the circle, and the angles are clockwise).     | `90`                          |
| Property | TrackColor         | The colour of the background track (the back, unfilled part of the slider)                                                | `Color.FromArgb("#ffdcdcdc")` |
| Property | TrackProgressColor | The colour of the progress track (the front, filled part of the slider)                                                   | `Color.FromArgb("#ffff0000")` |
| Property | TrackProgressWidth | The width of the progress track (the front, filled part of the slider)                                                    | `10`                          |
| Property | TrackWidth         | The width of the background track (the back, unfilled part of the slider)                                                 | `20`                          |
| Property | Value              | The `Value` of the slider.                                                                                                | `0`                           |
| Event    | ValueChanged       | Event fired when the value changes due to user interaction - same event args as the regular Xamarin.Forms Slider control. |                               |

