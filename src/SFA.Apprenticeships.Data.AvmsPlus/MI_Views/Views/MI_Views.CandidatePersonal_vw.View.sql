CREATE VIEW [MI_Views].[CandidatePersonal_vw]
AS
     SELECT dbo.Candidate.CandidateId,
            dbo.Candidate.PersonId,
            dbo.Candidate.DateofBirth,
            dbo.Candidate.AddressLine1,
            dbo.Candidate.AddressLine2,
            dbo.Candidate.AddressLine3,
            dbo.Candidate.AddressLine4,
            dbo.Candidate.AddressLine5,
            dbo.Candidate.Town,
            dbo.Candidate.Postcode,
            dbo.Candidate.UnconfirmedEmailAddress,
            dbo.Candidate.MobileNumberUnconfirmed,
            dbo.Person.Title,
            dbo.Person.OtherTitle,
            dbo.Person.FirstName,
            dbo.Person.MiddleNames,
            dbo.Person.Surname,
            dbo.Person.LandlineNumber,
            dbo.Person.MobileNumber,
            dbo.Person.Email,
            dbo.Candidate.Gender
     FROM dbo.Candidate
          INNER JOIN dbo.Person ON dbo.Candidate.PersonId = dbo.Person.PersonId
     WHERE(dbo.Candidate.CandidateStatusTypeId <> 6);