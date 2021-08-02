# test-project-01

#target

Lets assume we have 3 level hierarchy:
- Provider
- Profile
- Location

Provider 1-many Profile
Provider.ActiveProfileId point to actual version of profile

Profile 1-many Location
each Profile can have 1+ locations

Implement GetItems method

Methods recieve array pairs of { ProviderId, LocationId }
for example [{ providerId = 1, LocationId = null }, { providerId = 2, LocationId = "l-2" }, { providerId = 10, LocationId = "l-not-exsist"  }, { providerId = 5, LocationId = "l-5b" }]
should return objects in same order:

[
    { providerId = 1, LocationId = null, Profile = {...}, Location = {...}, Status = LocationNotFound },
    { providerId = 2, LocationId = "l-2", Profile = {...}, Location = {...}, Status = Found },
    { providerId = 10, LocationId = "l-not-exsist", Profile = {...}, Location = {...}, Status = ProvidrNotFound  },
    { providerId = 5, LocationId = "l-5b" }, Profile = {...}, Location = {...}, Status = Found }
}

if provideId & locationId exists => return both;
if providerId exists but locationId invalid => return provider and 1st location of active Providr Profile & status = LocationNotFound;
if providrId not exists => providerId & status = ProvidrNotFound;
if providerId exist but activeProfileId invalid => return providerId & status = InvalidProfile;

limitations:
Method shouldn't be used for getting more then 100 pairs per time, in most cases will be used to retrive 10-20 pairs