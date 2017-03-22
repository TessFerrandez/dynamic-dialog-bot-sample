-- Languages
	INSERT Languages
			(Id, Description)
			VALUES('en', 'English')
	INSERT Languages
			(Id, Description)
			VALUES('sv', 'Swedish')
-- SELECT * FROM Languages

-- Actions
	-- StartAction
	INSERT Actions
			(Id, ImageId, NextResponseId, ShortActionTextId, SideEffects, Slug, TextId, TrackingTags)
			VALUES('StartAction', NULL, 'StartResponse', 'StartAction_ActionText', NULL, 'StartAction', 'StartAction_Text', NULL)
	-- ToggleLanguageAction
	INSERT Actions 
			(Id, ImageId, NextResponseId, ShortActionTextId, SideEffects, Slug, TextId, TrackingTags)
			VALUES('ToggleLanguageAction', NULL, 'StartResponse', 'ToggleLanguageAction_ActionText', 'Toggle Language', 'ToggleLanguageAction', 'ToggleLanguageAction_Text', NULL)
	-- TellMeAJokeAction
	INSERT Actions
			(Id, ImageId, NextResponseId, ShortActionTextId, SideEffects, Slug, TextId, TrackingTags)
			VALUES('TellMeAJokeAction', NULL, 'TellMeAJokeResponse', 'TellMeAJokeAction_ActionText', NULL, 'TellMeAJokeAction', 'TellMeAJokeAction_Text', NULL)
	-- SaySomethingNiceAction
	INSERT Actions
			(Id, ImageId, NextResponseId, ShortActionTextId, SideEffects, Slug, TextId, TrackingTags)
			VALUES('SaySomethingNiceAction', NULL, 'SaySomethingNiceResponse', 'SaySomethingNiceAction_ActionText', NULL, 'SaySomethingNiceAction', 'SaySomethingNiceAction_Text', NULL)
	-- WhoAreYouAction
	INSERT Actions
			(Id, ImageId, NextResponseId, ShortActionTextId, SideEffects, Slug, TextId, TrackingTags)
			VALUES('WhoAreYouAction', NULL, 'WhoAreYouResponse', 'WhoAreYouAction_ActionText', NULL, 'WhoAreYouAction', 'WhoAreYouAction_Text', NULL)
-- SELECT * FROM Actions

-- Responses
	-- StartResponse
	INSERT Responses
			(Id, ImageId, IncludeDefaultAction, LinkId, MediaType, SearchHitTextId, Slug, TextId, VideoId)
			VALUES('StartResponse', NULL, 0, NULL, 'none', 'StartResponse_SearchHit', 'StartResponse', 'StartResponse_Text', NULL)
	-- TellMeAJokeResponse
	INSERT Responses
			(Id, ImageId, IncludeDefaultAction, LinkId, MediaType, SearchHitTextId, Slug, TextId, VideoId)
			VALUES('TellMeAJokeResponse', NULL, 0, NULL, 'none', 'TellMeAJokeResponse_SearchHit', 'TellMeAJokeResponse', 'TellMeAJokeResponse_Text', NULL)
	-- SaySomethingNiceResponse
	INSERT Responses
			(Id, ImageId, IncludeDefaultAction, LinkId, MediaType, SearchHitTextId, Slug, TextId, VideoId)
			VALUES('SaySomethingNiceResponse', NULL, 0, NULL, 'none', 'SaySomethingNiceResponse_SearchHit', 'SaySomethingNiceResponse', 'SaySomethingNiceResponse_Text', NULL)
	-- WhoAreYouResponse
	INSERT Responses
			(Id, ImageId, IncludeDefaultAction, LinkId, MediaType, SearchHitTextId, Slug, TextId, VideoId)
			VALUES('WhoAreYouResponse', NULL, 0, NULL, 'none', 'WhoAreYouResponse_SearchHit', 'WhoAreYouResponse', 'WhoAreYouResponse_Text', NULL)
	-- ErrorResponse
	INSERT Responses
			(Id, ImageId, IncludeDefaultAction, LinkId, MediaType, SearchHitTextId, Slug, TextId, VideoId)
			VALUES('ErrorResponse', NULL, 0, NULL, 'none', 'ErrorResponse_SearchHit', 'ErrorResponse', 'ErrorResponse_Text', NULL)
	-- DefaultResponse
	INSERT Responses
			(Id, ImageId, IncludeDefaultAction, LinkId, MediaType, SearchHitTextId, Slug, TextId, VideoId)
			VALUES('DefaultResponse', NULL, 0, NULL, 'none', 'DefaultResponse_SearchHit', 'DefaultResponse', 'DefaultResponse_Text', NULL)
	-- ReplayResponse
	INSERT Responses
			(Id, ImageId, IncludeDefaultAction, LinkId, MediaType, SearchHitTextId, Slug, TextId, VideoId)
			VALUES('ReplayResponse', NULL, 0, NULL, 'none', 'ReplayResponse_SearchHit', 'ReplayResponse', 'ReplayResponse_Text', NULL)
-- SELECT * FROM Responses

-- ResponseActions
	-- StartResponse
	INSERT ResponseActions
			(ResponseId, ActionId)
			VALUES('StartResponse', 'ToggleLanguageAction')
	INSERT ResponseActions
			(ResponseId, ActionId)
			VALUES('StartResponse', 'TellMeAJokeAction')
	INSERT ResponseActions
			(ResponseId, ActionId)
			VALUES('StartResponse', 'SaySomethingNiceAction')
	INSERT ResponseActions
			(ResponseId, ActionId)
			VALUES('StartResponse', 'WhoAreYouAction')
	-- TellMeAJokeResponse
	INSERT ResponseActions
			(ResponseId, ActionId)
			VALUES('TellMeAJokeResponse', 'TellMeAJokeAction')
	INSERT ResponseActions
			(ResponseId, ActionId)
			VALUES('TellMeAJokeResponse', 'StartAction')
	-- SaySomethingNiceResponse
	INSERT ResponseActions
			(ResponseId, ActionId)
			VALUES('SaySomethingNiceResponse', 'SaySomethingNiceAction')
	INSERT ResponseActions
			(ResponseId, ActionId)
			VALUES('SaySomethingNiceResponse', 'StartAction')
	-- WhoAreYouResponse
	INSERT ResponseActions
			(ResponseId, ActionId)
			VALUES('WhoAreYouResponse', 'StartAction')
	-- ErrorResponse
		-- Intentionally no actions here
	-- DefaultResponse
	INSERT ResponseActions
			(ResponseId, ActionId)
			VALUES('DefaultResponse', 'TellMeAJokeAction')
	INSERT ResponseActions
			(ResponseId, ActionId)
			VALUES('DefaultResponse', 'SaySomethingNiceAction')
	INSERT ResponseActions
			(ResponseId, ActionId)
			VALUES('DefaultResponse', 'WhoAreYouAction')
	-- ReplayResponse
	INSERT ResponseActions
			(ResponseId, ActionId)
			VALUES('ReplayResponse', 'TellMeAJokeAction')
	INSERT ResponseActions
			(ResponseId, ActionId)
			VALUES('ReplayResponse', 'SaySomethingNiceAction')
	INSERT ResponseActions
			(ResponseId, ActionId)
			VALUES('ReplayResponse', 'WhoAreYouAction')
-- SELECT * FROM ResponseActions


-- Texts
	-- StartAction_ActionText
	INSERT Texts
			(Id, LanguageId, Ordinal, Content)
			VALUES('StartAction_ActionText', 'en', 1, N'Start over')
	INSERT Texts
			(Id, LanguageId, Ordinal, Content)
			VALUES('StartAction_ActionText', 'sv', 1, N'Börja om')
	-- StartAction_Text
	INSERT Texts
			(Id, LanguageId, Ordinal, Content)
			VALUES('StartAction_Text', 'en', 1, N'Start over')
	INSERT Texts
			(Id, LanguageId, Ordinal, Content)
			VALUES('StartAction_Text', 'sv', 1, N'Börja om')
	-- ToggleLanguageAction_ActionText
	INSERT Texts
			(Id, LanguageId, Ordinal, Content)
			VALUES('ToggleLanguageAction_ActionText', 'en', 1, N'Swedish')
	INSERT Texts
			(Id, LanguageId, Ordinal, Content)
			VALUES('ToggleLanguageAction_ActionText', 'sv', 1, N'Engelska')
	-- ToggleLanguageAction_Text
	INSERT Texts
			(Id, LanguageId, Ordinal, Content)
			VALUES('ToggleLanguageAction_Text', 'en', 1, N'Swedish, please!')
	INSERT Texts
			(Id, LanguageId, Ordinal, Content)
			VALUES('ToggleLanguageAction_Text', 'sv', 1, N'Engelska, tack!')
	-- TellMeAJokeAction_ActionText
	INSERT Texts
			(Id, LanguageId, Ordinal, Content)
			VALUES('TellMeAJokeAction_ActionText', 'en', 1, N'Joke')
	INSERT Texts
			(Id, LanguageId, Ordinal, Content)
			VALUES('TellMeAJokeAction_ActionText', 'sv', 1, N'Vits')
	-- TellMeAJokeAction_Text
	INSERT Texts
			(Id, LanguageId, Ordinal, Content)
			VALUES('TellMeAJokeAction_Text', 'en', 1, N'Tell me a joke!')
	INSERT Texts
			(Id, LanguageId, Ordinal, Content)
			VALUES('TellMeAJokeAction_Text', 'sv', 1, N'Dra en vits!')
	-- SaySomethingNiceAction_ActionText
	INSERT Texts
			(Id, LanguageId, Ordinal, Content)
			VALUES('SaySomethingNiceAction_ActionText', 'en', 1, N'Nice')
	INSERT Texts
			(Id, LanguageId, Ordinal, Content)
			VALUES('SaySomethingNiceAction_ActionText', 'sv', 1, N'Snäll')
	-- SaySomethingNiceAction_Text
	INSERT Texts
			(Id, LanguageId, Ordinal, Content)
			VALUES('SaySomethingNiceAction_Text', 'en', 1, N'Say something nice about me!')
	INSERT Texts
			(Id, LanguageId, Ordinal, Content)
			VALUES('SaySomethingNiceAction_Text', 'sv', 1, N'Säg något snällt om mig!')
	-- WhoAreYouAction_ActionText
	INSERT Texts
			(Id, LanguageId, Ordinal, Content)
			VALUES('WhoAreYouAction_ActionText', 'en', 1, N'Who')
	INSERT Texts
			(Id, LanguageId, Ordinal, Content)
			VALUES('WhoAreYouAction_ActionText', 'sv', 1, N'Vem')
	-- WhoAreYouAction_Text
	INSERT Texts
			(Id, LanguageId, Ordinal, Content)
			VALUES('WhoAreYouAction_Text', 'en', 1, N'Who are you?')
	INSERT Texts
			(Id, LanguageId, Ordinal, Content)
			VALUES('WhoAreYouAction_Text', 'sv', 1, N'Vem är du?')
	-- StartResponse_SearchHit
	INSERT Texts
			(Id, LanguageId, Ordinal, Content)
			VALUES('StartResponse_SearchHit', 'en', 1, N'Start')
	INSERT Texts
			(Id, LanguageId, Ordinal, Content)
			VALUES('StartResponse_SearchHit', 'sv', 1, N'Start')
	-- StartResponse_Text
	INSERT Texts
			(Id, LanguageId, Ordinal, Content)
			VALUES('StartResponse_Text', 'en', 1, N'Hi and welcome to the dynamic dialog bot!##What do you want to do today?')
	INSERT Texts
			(Id, LanguageId, Ordinal, Content)
			VALUES('StartResponse_Text', 'sv', 1, N'Hej och välkommen till den dynamiska dialogboten##Vad vill du göra idag?')
	-- TellMeAJokeResponse_SearchHit
	INSERT Texts
			(Id, LanguageId, Ordinal, Content)
			VALUES('TellMeAJokeResponse_SearchHit', 'en', 1, N'Joke')
	INSERT Texts
			(Id, LanguageId, Ordinal, Content)
			VALUES('TellMeAJokeResponse_SearchHit', 'sv', 1, N'Vits')
	-- TellMeAJokeResponse_Text
	INSERT Texts
			(Id, LanguageId, Ordinal, Content)
			VALUES('TellMeAJokeResponse_Text', 'en', 1, N'RIP boiled water - you will be mist!')
	INSERT Texts
			(Id, LanguageId, Ordinal, Content)
			VALUES('TellMeAJokeResponse_Text', 'sv', 1, N'Hur många instagram går det på ett kilo?')
	INSERT Texts
			(Id, LanguageId, Ordinal, Content)
			VALUES('TellMeAJokeResponse_Text', 'en', 2, N'If it weren''t for C, we''d all be programming BASI and OBOL.')
	INSERT Texts
			(Id, LanguageId, Ordinal, Content)
			VALUES('TellMeAJokeResponse_Text', 'sv', 2, N'– Hur ser man att en norrman har försökt gå ut på nätet?##– Det är fotspår på skärmen.')
	INSERT Texts
			(Id, LanguageId, Ordinal, Content)
			VALUES('TellMeAJokeResponse_Text', 'en', 3, N'I''m reading a great book on anti-gravity. I can''t put it down.')
	INSERT Texts
			(Id, LanguageId, Ordinal, Content)
			VALUES('TellMeAJokeResponse_Text', 'sv', 3, N'– Golfspelaren slog sig själv med puttern!##– Ja, han greenar illa nu.')
	INSERT Texts
			(Id, LanguageId, Ordinal, Content)
			VALUES('TellMeAJokeResponse_Text', 'en', 4, N'Schrodinger''s cat walks into a bar. And doesn''t.')
	INSERT Texts
			(Id, LanguageId, Ordinal, Content)
			VALUES('TellMeAJokeResponse_Text', 'sv', 4, N'– Varför är det synd om fåglarna?##– Pengar växer inte på träd.')
	INSERT Texts
			(Id, LanguageId, Ordinal, Content)
			VALUES('TellMeAJokeResponse_Text', 'en', 5, N'What does a subatomic duck say? Quark')
	INSERT Texts
			(Id, LanguageId, Ordinal, Content)
			VALUES('TellMeAJokeResponse_Text', 'sv', 5, N'– Varför blir aldrig snön liggande i Glasgow?##– 600 000 skottar.')
	-- SaySomethingNiceResponse_SearchHit
	INSERT Texts
			(Id, LanguageId, Ordinal, Content)
			VALUES('SaySomethingNiceResponse_SearchHit', 'en', 1, N'Nice')
	INSERT Texts
			(Id, LanguageId, Ordinal, Content)
			VALUES('SaySomethingNiceResponse_SearchHit', 'sv', 1, N'Snällt')
	-- SaySomethingNiceResponse_Text
	INSERT Texts
			(Id, LanguageId, Ordinal, Content)
			VALUES('SaySomethingNiceResponse_Text', 'en', 1, N'If only the sun was as bright as you.')
	INSERT Texts
			(Id, LanguageId, Ordinal, Content)
			VALUES('SaySomethingNiceResponse_Text', 'sv', 1, N'Om ändå solen var lika skarp som du.')
	INSERT Texts
			(Id, LanguageId, Ordinal, Content)
			VALUES('SaySomethingNiceResponse_Text', 'en', 2, N'You can change the world.')
	INSERT Texts
			(Id, LanguageId, Ordinal, Content)
			VALUES('SaySomethingNiceResponse_Text', 'sv', 2, N'Du kan förändra världen.')
	INSERT Texts
			(Id, LanguageId, Ordinal, Content)
			VALUES('SaySomethingNiceResponse_Text', 'en', 3, N'Stand tall and proud##You have earned the right.')
	INSERT Texts
			(Id, LanguageId, Ordinal, Content)
			VALUES('SaySomethingNiceResponse_Text', 'sv', 3, N'Stå stolt och stark##Du förtjänar det.')
	INSERT Texts
			(Id, LanguageId, Ordinal, Content)
			VALUES('SaySomethingNiceResponse_Text', 'en', 4, N'I feel your strength')
	INSERT Texts
			(Id, LanguageId, Ordinal, Content)
			VALUES('SaySomethingNiceResponse_Text', 'sv', 4, N'Jag känner din styrka')
	INSERT Texts
			(Id, LanguageId, Ordinal, Content)
			VALUES('SaySomethingNiceResponse_Text', 'en', 5, N'Life is better when you are around.')
	INSERT Texts
			(Id, LanguageId, Ordinal, Content)
			VALUES('SaySomethingNiceResponse_Text', 'sv', 5, N'Livet blir bättre när du är här.')
	-- WhoAreYouResponse_SearchHit
	INSERT Texts
			(Id, LanguageId, Ordinal, Content)
			VALUES('WhoAreYouResponse_SearchHit', 'en', 1, N'Who')
	INSERT Texts
			(Id, LanguageId, Ordinal, Content)
			VALUES('WhoAreYouResponse_SearchHit', 'sv', 1, N'Vem')
	-- WhoAreYouResponse_Text
	INSERT Texts
			(Id, LanguageId, Ordinal, Content)
			VALUES('WhoAreYouResponse_Text', 'en', 1, N'I am the dynamic dialog bot! I tell jokes and say kind things.')
	INSERT Texts
			(Id, LanguageId, Ordinal, Content)
			VALUES('WhoAreYouResponse_Text', 'sv', 1, N'Jag är den dynamiska dialog boten! Jag drar vitsar och säger snälla saker.')
	-- ErrorResponse_SearchHit
	INSERT Texts
			(Id, LanguageId, Ordinal, Content)
			VALUES('ErrorResponse_SearchHit', 'en', 1, N'Error')
	INSERT Texts
			(Id, LanguageId, Ordinal, Content)
			VALUES('ErrorResponse_SearchHit', 'sv', 1, N'Fel')
	-- ErrorResponse_Text
	INSERT Texts
			(Id, LanguageId, Ordinal, Content)
			VALUES('ErrorResponse_Text', 'en', 1, N'Something happended on the way to heaven (or my back-end). Try to reconnect.')
	INSERT Texts
			(Id, LanguageId, Ordinal, Content)
			VALUES('ErrorResponse_Text', 'sv', 1, N'Nej, nu kommer jag inte åt mig själv! Prova att koppla upp igen.')
	-- DefaultResponse_SearchHit
	INSERT Texts
			(Id, LanguageId, Ordinal, Content)
			VALUES('DefaultResponse_SearchHit', 'en', 1, N'Default')
	INSERT Texts
			(Id, LanguageId, Ordinal, Content)
			VALUES('DefaultResponse_SearchHit', 'sv', 1, N'Standard')
	-- DefaultResponse_Text
	INSERT Texts
			(Id, LanguageId, Ordinal, Content)
			VALUES('DefaultResponse_Text', 'en', 1, N'I''m not very intelligent - about all I do is tell jokes and say nice things.')
	INSERT Texts
			(Id, LanguageId, Ordinal, Content)
			VALUES('DefaultResponse_Text', 'sv', 1, N'Jag är inte så smart - allt jag kan är att berätta vitsar och säga snälla saker.')
	-- ReplayResponse_SearchHit
	INSERT Texts
			(Id, LanguageId, Ordinal, Content)
			VALUES('ReplayResponse_SearchHit', 'en', 1, N'Replay')
	INSERT Texts
			(Id, LanguageId, Ordinal, Content)
			VALUES('ReplayResponse_SearchHit', 'sv', 1, N'Repris')
	-- ReplayResponse_Text
	INSERT Texts
			(Id, LanguageId, Ordinal, Content)
			VALUES('ReplayResponse_Text', 'en', 1, N'Here we go again!')
	INSERT Texts
			(Id, LanguageId, Ordinal, Content)
			VALUES('ReplayResponse_Text', 'sv', 1, N'Ok, vi tar det en gång till!')
-- SELECT * FROM Texts


-- Images
-- SELECT * FROM Images


-- Links
-- SELECT * FROM Links


-- Configs
	INSERT Configs
		(Id, DefaultActionId, DefaultResponseId, ErrorResponseId, ReplayResponseId, StartActionId)
		VALUES('Default', 'StartAction', 'DefaultResponse', 'ErrorResponse', 'ReplayResponse', 'StartAction') 
-- SELECT * FROM Configs

