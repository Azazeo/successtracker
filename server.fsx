#r @"packages/Suave/lib/net40/Suave.dll"

open Suave
open Suave.Http
open Suave.Http.Applicatives
open Suave.Http.Successful
open Suave.Web


type Knoledge = KnoledgeName * KnoledgeDetails
and KnoledgeName = KnoledgeName of string
and KnoledgeDetails = KnoledgeDetails of string option

type Skill = SkillName * SkillDetails
and SkillName = SkillName of string
and SkillDetails = SkillDetails of string option

type DoneWork = DoneWorkName * DoneWorkDetails
and DoneWorkName = DoneWorkName of string
and DoneWorkDetails = DoneWorkDetails of string option

type FinishedWork = FinishedWorkName * FinishedWorkDetails
and FinishedWorkName = FinishedWorkName of string
and FinishedWorkDetails = FinishedWorkDetails of string option


type SuccessItem =
    | Knoledge of Knoledge
    | Skill of Skill
    | DoneWork of DoneWork
    | FinishedWork of FinishedWork


let application =
    choose
        [ GET >>= choose
            [path "/index" >>= OK "Hello there!"]
          POST >>= choose
            [path "/add" >>= OK "Posted something"]
        ]
        

startWebServer defaultConfig (OK "Hello world")