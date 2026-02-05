import { createFileRoute } from "@tanstack/react-router"
import { Base } from "#/common/layouts/base"

export const Route = createFileRoute("/login")({
  component: RouteComponent,
})

function RouteComponent() {
  return (
    <Base>
      <p>- خالی -</p>
    </Base>
  )
}
