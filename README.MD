## Original Inspiration
Inspiration for this KATA can be found from the [Mars Rover kata] Kata Logs site (http://kata-log.rocks/mars-rover-kata)

## Purpose
This exercise is designed to give developers practice in the following:
- TDD on a given set of requirements
- Get used to the unit testing tool (MsTest) as well as a mocking framework (Moq)
- Get used to the [test naming conventions](https://s1wiki.atlassian.net/wiki/spaces/EN/pages/515342477/Automated+Testing+Conventions)
- Good class and interface design (for example, leveraging an interface for logging, not depending upon a static instance)
- For those new to .NET, experience adding projects, files, and interacting with common libraries

## Environment Requirements
- Visual Studio 2017
- .NET Framework (v 4.7.2)

## Task
You’re part of the team that explores Mars by sending remotely controlled vehicles to the surface of the planet. Develop an API that translates the commands sent from earth to instructions that are understood by the rover.

## Requirements
- The rover always starts at (0,0) facing N.
- The rover receives a character array of commands.
- The rover must log it's current position after receiving a command.
- Implement commands that move the rover forward/backward (f,b).
- Implement commands that turn the rover left/right (l,r).
- No third party libraries outside .Net Framework & Moq.
- One person conducting this exercise should have run through it before.

## Process
- Initialize git repository for work.
- Sit down and read requirements, fill in gaps as needed.
- Brainstorm domain model for concepts involved.
- Pick starting point (ie Rover) to begin TDD/Pair Programming/Ping Pong Programming.
    - A writes a new test and sees that it fails.
    - B implements the code needed to pass the test.
    - Talk about if there is stuff to refactor (business or test code, one at a time).
    - Commit work locally.
    - Person A & B swap places and repeat the process.

## Resources
https://ardalis.com/rgrc-is-the-new-red-green-refactor-for-test-first-development