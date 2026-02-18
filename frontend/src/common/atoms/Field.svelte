<script lang="ts">
  import type { ChildrenRequired } from "../utils";
  import { field } from "./field";

  const { container, label } = field();

  type Props = ChildrenRequired & {
    title: string;
  };

  let { title, children }: Props = $props();
</script>

<div class={container()}>
  <p dir="auto" class={label()}>
    {title}:
  </p>

  {@render children()}
</div>
