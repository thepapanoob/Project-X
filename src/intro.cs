public class Intro
{
    public static void SmokieIntro()
    {
        Lua.LuaDoString(@"
            if not SmokieFrame then
                SmokieFrame = CreateFrame(""Frame"")
                SmokieFrame:ClearAllPoints()
                SmokieFrame:SetBackdrop(StaticPopup1:GetBackdrop())
                SmokieFrame:SetHeight(100)
                SmokieFrame:SetWidth(750)

                SmokieFrame.text = SmokieFrame:CreateFontString(nil, ""BACKGROUND"", ""GameFontNormal"")
                SmokieFrame.text:SetAllPoints()
                SmokieFrame.text:SetText(""Project X - Thank you for choosing project X. Please dont forget to show us your support by leaving a like on our post and leaving a review. For all bug reports, please join our discord :  https://discord.gg/xQuhs5C "")
                SmokieFrame.text:SetTextColor(1, 1, 1, 6)
                SmokieFrame:SetPoint(""CENTER"", 0, -10)
                SmokieFrame:SetBackdropBorderColor(100, 1, 1, 10)



                SmokieFrame:SetMovable(true)
                SmokieFrame:EnableMouse(true)
                SmokieFrame:SetScript(""OnMouseDown"",function() SmokieFrame:StartMoving() end)
                SmokieFrame:SetScript(""OnMouseUp"",function() SmokieFrame:StopMovingOrSizing() end)

                SmokieFrame.Close = CreateFrame(""BUTTON"", nil, SmokieFrame, ""UIPanelCloseButton"")
                SmokieFrame.Close:SetWidth(25)
                SmokieFrame.Close:SetHeight(25)
                SmokieFrame.Close:SetPoint(""TOPRIGHT"", SmokieFrame, -8, -8)
                SmokieFrame.Close:SetScript(""OnClick"", function()
                    SmokieFrame:Hide()
                    DEFAULT_CHAT_FRAME:AddMessage(""SmokieStatusFrame |cffC41F3Bclosed |cffFFFFFFWrite /DKSmokie to enable again."")  
                end)

                SLASH_WHATEVERYOURFRAMESARECALLED1=""/DKSmokie""
                SlashCmdList.WHATEVERYOURFRAMESARECALLED = function()
                    if SmokieFrame:IsShown() then
                        SmokieFrame:Hide()
                    else
                        SmokieFrame:Show()
                    end
                end
            end"
        );
    }
}