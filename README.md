ImprovedAPIDocs
===============

This was started during the Hackathon, but after hammering through each type of problem I would run into, I realized that the concept is actually very possible.

Once the architecture is solid and cleaned up (a lot), I'll create a more formal Wiki, but the project is currently slightly messy.

I have already passed the main hurdles of handling large amounts of GET/POST data from web forms, but the current strategy involves a lot of typing.


Current Goals
=============

- Controllers need to be simplified and aggregate more data from their models
- Preferrably, common requests need to be generic. The difficulty is that each API service lies in a completely different namespace.
- Possibly create a generic response page, rather than one for each request.
- Clean up the architecture in general; I've had to speed through quite a bit to achieve the main concept