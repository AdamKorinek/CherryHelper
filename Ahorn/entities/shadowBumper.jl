module CH_ShadowBumper

using ..Ahorn, Maple
@mapdef Entity "CherryHelper/ShadowBumper" ShadowBumper(x::Integer, y::Integer, wiggles::Bool=true)
const placements = Ahorn.PlacementDict(
    "Shadow Dash Bumper (Cherry Helper)" => Ahorn.EntityPlacement(
        ShadowBumper
    )
)

Ahorn.nodeLimits(entity::ShadowBumper) = 0, 1

sprite = "objects/shadowBumper/shadow22.png"

function Ahorn.selection(entity::ShadowBumper)
    x, y = Ahorn.position(entity)
    nodes = get(entity.data, "nodes", ())

    if !isempty(nodes)
        nx, ny = Int.(nodes[1])

        return [Ahorn.getSpriteRectangle(sprite, x, y), Ahorn.getSpriteRectangle(sprite, nx, ny)]
    end

    return Ahorn.getSpriteRectangle(sprite, x, y)
end

function Ahorn.renderSelectedAbs(ctx::Ahorn.Cairo.CairoContext, entity::ShadowBumper)
    x, y = Ahorn.position(entity)
    nodes = get(entity.data, "nodes", ())

    if !isempty(nodes)
        nx, ny = Int.(nodes[1])

        theta = atan(y - ny, x - nx)
        Ahorn.drawArrow(ctx, x, y, nx + cos(theta) * 8, ny + sin(theta) * 8, Ahorn.colors.selection_selected_fc, headLength=6)
        Ahorn.drawSprite(ctx, sprite, nx, ny)
    end
end

Ahorn.render(ctx::Ahorn.Cairo.CairoContext, entity::ShadowBumper, room::Maple.Room) = Ahorn.drawSprite(ctx, sprite, 0, 0)

end