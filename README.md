# Frends.Community.ExcelFinancialFunctions

Frends tasks for financial calculations using Excel Financial Functions

[![Actions Status](https://github.com/CommunityHiQ/Frends.Community.ExcelFinancialFunctions/workflows/PackAndPushAfterMerge/badge.svg)](https://github.com/CommunityHiQ/Frends.Community.ExcelFinancialFunctions/actions) ![MyGet](https://img.shields.io/myget/frends-community/v/Frends.Community.ExcelFinancialFunctions) [![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT) 

- [Installing](#installing)
- [Tasks](#tasks)
     - [XIrrTools](#XIrrTools)
- [Building](#building)
- [Contributing](#contributing)
- [Change Log](#change-log)

# Installing

You can install the Task via frends UI Task View or you can find the NuGet package from the following NuGet feed
https://www.myget.org/F/frends-community/api/v3/index.json and in Gallery view in MyGet https://www.myget.org/feed/frends-community/package/nuget/Frends.Community.ExcelFinancialFunctions

# Tasks

## XIrrTools

Task calculates XIrr value using Newtons method

### Properties

| Property | Type | Description | Example |
| -------- | -------- | -------- | -------- |
| Input | `string` | JArray string with values and dates. | `[{value: 1.234, date: "2021-05-25"}, {value: 2.345, date: "2022-05-25"}]` |

### Options

| Property | Type | Description | Example |
| -------- | -------- | -------- | -------- |
| Tolerance | `double` | Tolerance used in calculations. | `0.00000001` |
| MaxIterations | `int` | Max. number of iterations while calculating Xirr value. | `100` |

### Returns

A result object with parameters.

| Property | Type | Description | Example |
| -------- | -------- | -------- | -------- |
| Value | `string` | Calculated XIrr value. | `77.4425237947709` |

Usage:
To fetch result use syntax:

`#result.Value`

# Building

Clone a copy of the repository

`git clone https://github.com/CommunityHiQ/Frends.Community.ExcelFinancialFunctions.git`

Rebuild the project

`dotnet build`

Run tests

`dotnet test`

Create a NuGet package

`dotnet pack --configuration Release`

# Contributing
When contributing to this repository, please first discuss the change you wish to make via issue, email, or any other method with the owners of this repository before making a change.

1. Fork the repository on GitHub
2. Clone the project to your own machine
3. Commit changes to your own branch
4. Push your work back up to your fork
5. Submit a Pull request so that we can review your changes

NOTE: Be sure to merge the latest from "upstream" before making a pull request!

# Change Log

| Version | Changes |
| ------- | ------- |
| 0.1.1   | Development still going on |
| 0.1.2   | First working version of the task |
| 0.1.3   | Changes to property namings |
| 0.1.4   | Test case created, README updated |
| 0.1.5   | Fixed input tab |
| 0.1.6   | Minor changes to descriptions |
